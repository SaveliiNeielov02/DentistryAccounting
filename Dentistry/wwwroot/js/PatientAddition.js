document.addEventListener('DOMContentLoaded', function () {
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
                button.addEventListener('mouseenter', function () {
                    this.classList.add('hovered');
                });

                button.addEventListener('mouseleave', function () {
                    this.classList.remove('hovered');
                });

                button.addEventListener('click', function () {
                    this.isClicked = !this.isClicked;
                    this.classList.toggle('clicked');
                });

                rowDiv.appendChild(button);
            }
        }

        teethDiv.appendChild(rowDiv);
    }
});

function addData(event) {
    event.preventDefault();
    const name = document.getElementById("name").value;
    const surname = document.getElementById("surName").value;
    const patronymic = document.getElementById("patronymic").value;
    const phoneNumber = document.getElementById("phoneNumber").value;
    const type = document.getElementById("type").value;
    const description = document.getElementById("description").value;
    var toothList = [];
    var toothButtons = document.getElementsByClassName('tooth-button');
    const phoneNumberPattern = /^(\+?380\s?\d{2}\s?\d{3}\s?\d{2}\s?\d{2}|\d{3}\s?\d{3}\s?\d{2}\s?\d{2})$/;
    if (!phoneNumberPattern.test(phoneNumber)) {
        alert("Номер телефона введен в неправильном формате. Допускается +380 xx xxx xx xx или xxx xxx xx xx");
        return;
    }
    for (var i = 0; i < toothButtons.length; i++) {

        if (toothButtons[i].isClicked) {
            toothList.push(toothButtons[i].textContent);
        }
    }
    var currentDate = new Date();
    currentDate.setHours(0, 0, 0, 0);
  
    var formData = {
        Name: name,
        Surname: surname,
        Patronymic: patronymic,
        PhoneNumber: phoneNumber,
        OperationTypeName: type,
        OperationNotices: description,
        OperationsTooth: toothList,
        ReceptionDate: currentDate,
    };
    
    var json = JSON.stringify(formData);
    console.log(json);
    $.ajax({
        type: "POST", // Метод запроса (POST)
        url: "/PatientAddition/AddPatient", // URL метода контроллера
        data: json, // Преобразуем объект data в JSON-строку и отправляем в теле запроса
        contentType: "application/json", // Use "application/json" without the charse
        success: function (response) {
            alert(response.message);
        },
        error: function (xhr, textStatus, errorThrown) {
            // Обработка ошибки
            alert("Ошибка при отправке данных на сервер");
        }
    });
}