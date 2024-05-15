buttonEp = document.getElementById("btnEp")
modal = document.querySelector("dialog")
buttonCancel = document.getElementById("cancelBtn")
buttonSave = document.getElementById("saveBtn")


buttonEp.onclick = function() {
    modal.showModal()
}

buttonCancel.onclick = function() {
    modal.close()
}

buttonSave.onclick = function() {
    modal.close()
}