document.addEventListener("DOMContentLoaded", function ()
{
    var likeButtons = document.querySelectorAll(".likeButton");
    likeButtons.forEach(function(button){

        var eventId = this.getAttribute('data-event-id');
        var data = {
            eventId: eventId
        };
        
        var req = new XMLHttpRequest();
        req.open("POST", "Like/LikeEvent", true);
        req.setRequestHeader("Content-Type", "Application/x-www-form-urlencoded");
        req.onreadystatechange = function () {
            if (req.readyState == XMLHttpRequest.DONE) {
                if (req.readyState == 200) {
                    var response = JSON.parse(req.responseText);
                    if (response.success)
                        alert("curtido com sucesso");
                    else
                        alert("erro ao curtir");
                }
                else {
                    alert("erro ao tentar curtir o evento");
                }
            }
        }
        req.send(JSON.stringify(data));



    });
})