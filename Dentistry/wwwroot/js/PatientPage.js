document.addEventListener('DOMContentLoaded', function () {
    var patientsDataElement = document.getElementById('patientsData');
    var patientsReceptionsID = JSON.parse(patientsDataElement.getAttribute('data-patients'));
    let receptionsList = [];
    $.ajax({
        type: "GET",
        url: "/PatientPage/GetReceptions/" + patientsReceptionsID.join(','),
        contentType: "application/json",
        success: async function (patients) {
            const promises = patients.map(async function (patient) {
                try {
                    const typeName = await $.ajax({
                        type: "GET",
                        url: "/PatientPage/GetType/" + patient.operationTypeID,
                        contentType: "application/json"
                    });
                    patient.operationTypeName = typeName;
                    receptionsList.push(patient);
                } catch (error) {
                    console.error("Ошибка при получении типа операции:", error);
                }
            });
            await Promise.all(promises); 
            editToothRow(receptionsList); 
        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Ошибка при получении данных с сервера");
        }
    });

    var teethDiv = document.getElementsByClassName('teeth').item(0);

    for (let row = 0; row < 2; row++) {
        var rowDiv = document.createElement('div');
        rowDiv.className = 'tooth-row';

        for (let col = -8; col < 9; col++) {
            if (col != 0) {
                var button = document.createElement('button');
                button.className = 'tooth-button';
                button.type = 'button';
                if (row == 0) {
                    button.textContent = (col.toString() + '⇑').toString();
                }
                else {
                    button.textContent = (col.toString() + '⇓').toString();
                }
                button.isClicked = false;
                rowDiv.appendChild(button);
            }
        }

        teethDiv.appendChild(rowDiv);
    }
});


function editToothRow(receptionsList) {
    var toothButtons = document.getElementsByClassName('tooth-button');
    for (const reception of receptionsList) {
        for (var i = 0; i < toothButtons.length; i++) {

            if (reception.operationsTeeths.includes(toothButtons[i].textContent)) {
                toothButtons[i].isClicked = true;
                toothButtons[i].classList.toggle('clicked');
            }
        }
    }
    
}