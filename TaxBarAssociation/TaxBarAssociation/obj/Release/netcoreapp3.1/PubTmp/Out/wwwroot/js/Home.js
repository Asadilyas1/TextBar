function PagerClick(index) {
    document.getElementById("hfCurrentPageIndex").value = index;
    document.forms[0].submit();
}
function DisplayProgressMessage(msg) {
    // Gray out background on page
    $("body").addClass("submit-progress-bg");
    // Wrap in setTimeout so the UI can update the spinners
    $(".submit-progress").removeClass("hidden");
    //submit the form.
    //setTimeout(function () {
    //    $("form").submit();
    //}, 1);
    return true;
}

$.ajax({
    type: "GET",
    url: "/Home/LoadSettings",
    data: {},
    dataType: 'json',
    beforeSend: function () {
        DisplayProgressMessage('Saving...');
    },
    success: function (res) {
        var title = $('title').text() + res.appName;
        document.title = title;
        let logoImg = document.getElementsByClassName("logoImg");
        if (res.logo != null && res.logo != "") {
            logoImg[0].src = `data:image/*;base64,${res.logo}`;
            logoImg[1].src = `data:image/*;base64,${res.logo}`;
        } else {
            logoImg[0].src = '../../website/images/Main-Logo.png';
            logoImg[1].src = '../../website/images/Main-Logo.png';
        }
        document.getElementById("headerText").innerText = res.headerText;
        let contactText = document.getElementById("contact-text");
        if (contactText != null) {
            contactText.innerText = res.contactText;
            let location = document.getElementsByClassName("location");
            location[0].href = `http://maps.google.com/?q=1200 ${res.location}`;
            location[1].href = `http://maps.google.com/?q=1200 ${res.location}`;
            location[0].target = "_blank";
            location[1].target = "_blank";
            location[0].innerHTML = `<i class="energia-arrow-right"></i>global office map`;
            location[1].innerHTML = `${res.location}`;
            document.getElementById("telephone").innerText = res.contactNumber;
            document.getElementById("timing").innerText = `${res.day}: ${res.startTime} - ${res.endTime}`;
            let map = res.map.replace(/%20/g, " ");
            document.getElementById("map-frame").src = map.replace(/\s/g, '');
        }
    },
    error: function (res) {
        alert(res);
    },
    complete: function () {
        // Gray out background on page
        $("body").removeClass("submit-progress-bg");
        // Wrap in setTimeout so the UI can update the spinners
        $(".submit-progress").addClass("hidden");
    }
});

$.ajax({
    type: "GET",
    url: "/Home/LoadBlogs",
    data: {},
    dataType: 'html',
    beforeSend: function () {
        DisplayProgressMessage('Saving...');
    },
    success: function (res) {
        $("#LoadBlogs").html(res);
    },
    error: function (res) {
        alert(res);
    },
    complete: function () {
        // Gray out background on page
        $("body").removeClass("submit-progress-bg");
        // Wrap in setTimeout so the UI can update the spinners
        $(".submit-progress").addClass("hidden");
    }
});