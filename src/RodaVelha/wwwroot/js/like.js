document.addEventListener("DOMContentLoaded", function ()
{
    var likeButtons = document.querySelectorAll(".likeButton");
    likeButtons.forEach(button => {
        button.addEventListener('click', function () {

            var eventId = this.getAttribute('data-event-id');
            console.log(eventId);

            var req = new XMLHttpRequest();
            req.open("POST", "/Like/LikeEvent", true);
            req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            req.onreadystatechange = function () {
                if (req.readyState === XMLHttpRequest.DONE) {
                    if (req.status === 200) {
                        var response = JSON.parse(req.responseText);
                        if (response.success)
                            alert("Curtido com sucesso!");
                        else
                        {
                            console.log(response);
                            alert("Usuário já curtiu este evento!");
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