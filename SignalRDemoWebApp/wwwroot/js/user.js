
"use strict";




const connection = new signalR.HubConnectionBuilder().withUrl("/client-hub").withAutomaticReconnect([0, 1000, 10000]).build();


const timestamp = document.getElementById("time").value;
const buttonCheckin = document.getElementById("btnCheckin");
const buttonCheckOut = document.getElementById("btnCheckout");
const username = prompt("Please enter your name");
connection.on("ReceiveUserInfo", (username) => {
    let li = document.createElement("li");
    document.getElementById("userList").appendChild(li);
    li.innerText = `At ${timestamp} ${username} has checkin`;
})

connection.on("CheckOutUser", (username) => {
    let li = document.createElement("li");
    document.getElementById("logList").appendChild(li);
    li.innerText = `At ${timestamp} ${username} has checkout`;

})
connection.start();
buttonCheckin.addEventListener("click", () => {


    connection.invoke("SendNotyf", username).catch(err => console.error(err.toString())
    );

    $.ajax({
        url: '/Login/Create',
        method: 'POST',
        data: { username: username, content: `${username} has checkin` },
        success: () => {
            loadData();
        }
    })


});

buttonCheckOut.addEventListener("click", () => {

    connection.invoke("CheckOut", username).catch(err => console.error(err.toString()));
    $.ajax({
        url: '/Login/Create',
        method: 'POST',
        data: { username: username, content: `${username} has checkout` },
        success: () => {
            loadData();
        }
    })
});

const loadData = () => {
    document.getElementById("dataList").innerHTML = "";
    $.ajax({
        url: '/Login/GetData',
        method: 'GET',
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: (data) => {
            data.forEach(element => {
                let li = document.createElement("li");
                document.getElementById("dataList").appendChild(li);
                li.innerText = `At ${element.TimeCreate} ${element.Content}`;
            });
        }
    })
}
loadData();







