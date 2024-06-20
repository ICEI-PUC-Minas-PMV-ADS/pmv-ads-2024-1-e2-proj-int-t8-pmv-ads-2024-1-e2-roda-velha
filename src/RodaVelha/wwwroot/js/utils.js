

function navigateToPage() {
        var select = document.getElementById("pageSelect");
    var url = select.value;
    if (url) {
        window.location.href = url;
        }
    }
