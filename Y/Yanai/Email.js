function sendEmail() {
    if (localStorage["Email"]) {
        Email.send({
            Host: "smtp.gmail.com",
            Username: "yanaybtz@gmail.com",
            Password: "noyshir1",
            To: JSON.parse(localStorage["Email"]),
            From: "yanaybtz@gmail.com",
            Subject: "תלונה חדשה מלקוח מס' " + JSON.parse(localStorage["cusId"]),
            Body: "לחץ על הקישור על מנת להיכנס לטופס התלונה: http://proj.ruppin.ac.il/igroup14/prod/editManagerComplaintLink.html?" + JSON.parse(localStorage["CompId"])
        })
    }
    if (localStorage["EmailsInformed"]) {
        Email.send({
            Host: "smtp.gmail.com",
            Username: "yanaybtz@gmail.com",
            Password: "noyshir1",
            To: JSON.parse(localStorage["EmailsInformed"]),
            From: "yanaybtz@gmail.com",
            Subject: "תלונה חדשה מלקוח מס' " + JSON.parse(localStorage["cusId"]),
            Body: "לחץ על הקישור על מנת להיכנס לטופס התלונה: http://proj.ruppin.ac.il/igroup14/prod/editManagerComplaintLink.html?" + JSON.parse(localStorage["CompId"])
        })
    }
    if (localStorage["EmailTreatment"]) {
        Email.send({
            Host: "smtp.gmail.com",
            Username: "yanaybtz@gmail.com",
            Password: "noyshir1",
            To: JSON.parse(localStorage["EmailTreatment"]),
            From: "yanaybtz@gmail.com",
            Subject: "תלונה מס' " + JSON.parse(localStorage["CompId"]) + " הועברה לטיפולך",
            Body: "לחץ על הקישור על מנת להיכנס לטופס התלונה: http://proj.ruppin.ac.il/igroup14/prod/editManagerComplaintLink.html?" + JSON.parse(localStorage["CompId"])
        })
    }
    if (localStorage["EmailsComments"]) {
        Email.send({
            Host: "smtp.gmail.com",
            Username: "yanaybtz@gmail.com",
            Password: "noyshir1",
            To: JSON.parse(localStorage["EmailsComments"]),
            From: "yanaybtz@gmail.com",
            Subject: "התקבלה תגובה חדשה בתלונה מס' " + JSON.parse(localStorage["CompId"]),
            Body: "לחץ על הקישור על מנת להיכנס לטופס התלונה: http://proj.ruppin.ac.il/igroup14/prod/editManagerComplaintLink.html?" + JSON.parse(localStorage["CompId"])
        })
    }
}