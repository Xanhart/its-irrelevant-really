$(document).ready(function () {
    function hasGetUserMedia() {
        return !!(navigator.mediaDevices && navigator.mediaDevices.getUserMedia);
    }

    if (hasGetUserMedia()) {
        // Good to go!
    } else {
        alert('getUserMedia() is not supported by your browser');
    }

    var selectedAnimal = null;

    $(".photo-btn").click(function () {
        $("#animal-select").hide();
        $("#take-picture").show();

        selectedAnimal = $(this)[0].innerText.trim()
        
    })

    $("#submitbutton").click(function () {
        var image = canvas.toDataURL('image/png')



        function postPhoto() {
            var photoData = {
                PhotoAnimalName: selectedAnimal
            }

            $.post("photos/Create", photoData, function (data) {
                console.log(data)
            })
        }

        
    })

});