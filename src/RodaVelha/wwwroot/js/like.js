document.addEventListener("DOMContentLoaded", function ()
{
    var likeButton = document.getElementById("likeButton");
    likeButton.addEventListener("click", function () {
        var eventId = this.getAttribute("data-event-id");

        var req = new XMLHttpRequest();
        req.open("POST", "Like/LikeEvent", true);
        req.setRequestHeader("Content-Type", "pplication/x-www-form-urlencoded");
        req.onreadystatechange = function () {
            if (req.readyState == 4) {
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
        req.send("eventId=" + encodeURIComponent(eventId));
    });
})