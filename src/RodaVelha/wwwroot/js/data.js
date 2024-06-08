document.addEventListener("DOMContentLoaded", function () {
    var likeButtons = document.querySelectorAll(".deleteButton");
    likeButtons.forEach(button => {
        button.addEventListener('click', function () {

            var eventId = this.getAttribute('data-id');
            var req = new XMLHttpRequest();
            req.open("POST", "/Events/DeleteEvent", true);
            req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            req.onreadystatechange = function () {
                if (req.readyState === XMLHttpRequest.DONE) {
                    if (req.status === 200) {
                        var response = JSON.parse(req.responseText);
                        if (response.success) {
                            Swal.fire({
                                position: "center",
                                title: `Informação!`,
                                text: "Evento apagado com sucesso!",
                                icon: "success",
                                showConfirmButton: false,
                                timer: 1500,
                            });
                            setTimeout(function () {
                                location.reload();
                            }, 2000); 

                        }
                        else {
                            Swal.fire({
                                position: "center",
                                title: `Erro!`,
                                text: response.message,
                                icon: "error",
                                showConfirmButton: false,
                                timer: 2000,
                            });
                        }

                    }
                    else {
                        alert("erro ao tentar apagar o evento");
                    }
                }
            }
            req.send("id=" + encodeURIComponent(eventId));

        });




    });
})