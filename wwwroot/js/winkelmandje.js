function changeQuantity(action, itemId) {
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/Winkelmandje/UpdateQuantity", true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify({
        action: action,
        itemId: itemId
    }));
    xhr.onload = function () {
        if (xhr.status === 200) {
            location.reload(); // Herlaad de pagina om de nieuwe hoeveelheid weer te geven
        }
    };
}