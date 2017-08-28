(function() {
    $("body").on("click",
        ".jsViewGroups",
        function () {
            var $tr = $(this).closest("tr");
            var $td = $tr.find(".jsUserData");

            var userId = $td.find(".jsUserId").val();
            var userName = $td.find(".jsUserName").text();

            $.get("/Home/UserGroups?userId=" + userId).done(function (response) {
                if (response) {
                    var $modal = $("#modalWindow");

                    $modal.find(".modal-title").text("Membership for " + userName);

                    $modal.find(".modal-body").html(response);

                    $modal.modal();
                }
            });            
        });
})();