
/* -------------Menu------------------*/
try {
    const toggleBtn = document.querySelector('[data-option="toggle"]')
    const menuLinks = document.getElementById("menu")

    toggleBtn.addEventListener("click", function () {
        const element = document.getElementById("icon")

        if (element.classList.contains("fa-bars")) {
            element.classList.add("fa-xmark")
            element.classList.remove("fa-bars")
            menuLinks.classList.remove("d-none")
        }

        else {
            element.classList.add("fa-bars")
            element.classList.remove("fa-xmark")
            menuLinks.classList.add("d-none")
        }
    })
} catch { }


/* -------------Product detail quantity element------------------*/
var i = 1;
const qtyInput = document.getElementById("qty")
const buttonClickInc = () => {
    i++;
    qtyInput.value = i;
}
const buttonClickDec = () => {
    if (i <= 1) { }
    else {
        i--;
        qtyInput.value = i;
    }
}

/* -------------Product detail tabs------------------*/
const productColapse = document.querySelectorAll("#productColapse");
const toggleColapse = (i) => {
    productColapse[i].classList.toggle("active")
    productColapse[i].classList.toggle("product-colapse-toggle-active")
}