

$(document).ready(function () {

    $('.ui.menu')
        .on('click', '.item', function () {
            if (!$(this).hasClass('dropdown')) {
                $(this)
                    .addClass('active')
                    .siblings('.item')
                    .removeClass('active');
            }
        });

    var connection = new signalR.HubConnectionBuilder().withUrl("/EmergencyHub").build();

    var types = ['/imgs/policeman.png', '/imgs/firefighter.png', '/imgs/nurse.png', '/imgs/worker.png'];

    connection.on("ReceiveReport", function (person, report) {

        var icon;
        switch (report.reportType) {
            case 0:
                icon = types[0];
                break;
            case 1:
                icon = types[1];
                break;
            case 2:
                icon = types[2];
                break;
            case 3:
                icon = types[3];
                break;
            default:
        }

        var text = `
                <div class="item">
                    <div class="image">
                        <img src="`+ icon + `">
                    </div>
                    <div class="content">
                        <a class="header">`+ person.name + `</a>
                        <div class="meta">
                            <span>Description</span>
                        </div>
                        <div class="description">
                            <p id="age">Age: `+ person.age + `</p>
                            <p id="bloodType">Blood Type: `+ person.bloodType + `</p>
                        </div>
                        <div class="extra">
                            Location: `+ report.location + `
                        </div>
                    </div>
                </div>
                   `;


        $('#case').append(text);
    });


    $('#send').on('click', function () {

        let person = { name: "Abdo Mursal", age: 15, bloodType: "A++" };
        let report = { reportType: 3, location: "International Islamic University Malaysia - Gombak" };
        console.log(person);
        console.log(report);
        connection.invoke("ReportEmergency", person, report).catch(function (err) {
            return console.error(err.toString());
        });
    });

    connection.start().then(function () {
        console.log("connected");
    });

});