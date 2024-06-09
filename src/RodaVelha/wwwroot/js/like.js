document.addEventListener("DOMContentLoaded", function ()
{
    var likeButtons = document.querySelectorAll(".likeButton");
    likeButtons.forEach(button => {
        button.addEventListener('click', function () {

            var eventId = this.getAttribute('data-event-id');

            var req = new XMLHttpRequest();
            req.open("POST", "/Like/LikeEvent", true);
            req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            req.onreadystatechange = function () {
                if (req.readyState === XMLHttpRequest.DONE) {
                    if (req.status === 200) {
                        var response = JSON.parse(req.responseText);
                        if (response.success)
                        {
                            
                            var likeElement = document.getElementById(eventId);
                            var likeQuantity = parseInt(likeElement.getAttribute('data-like'));
                            console.log(likeQuantity);
                            console.log(likeElement);
                            document.getElementById(eventId).innerHTML = ((" " + (likeQuantity + 1) + " pessoas"));
                           
                            Swal.fire({
                                position: "center",
                                title: `Parabéns!`,
                                text: "Seu like foi efetuado com sucesso!",
                                icon: "success",
                                showConfirmButton: false,
                                timer: 1500,
                            });
                           


                        }
                        else
                        {
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
                        alert("erro ao tentar curtir o evento");
                    }
                }
            }
            req.send("eventId=" + encodeURIComponent(eventId) );

        });
        



    });
})