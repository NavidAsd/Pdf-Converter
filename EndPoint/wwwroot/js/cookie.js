async function setCookie() {
    await fetch('/accept', {
        method: "POST",
        body: ""
    })
        .then(response => response.json())
        .then((data) => {
            if (data.success) {
                slideDown(document.getElementsByClassName('section-cookie')[0]);
            }
        })
}

function slideDown(obj) {
    obj.style.height = "0px";
    setTimeout(() => {
        obj.style.padding = "0px";
    }, 250)
}
