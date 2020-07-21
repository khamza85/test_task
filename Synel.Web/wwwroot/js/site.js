// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(".custom-file-input").on("change", function() {
    const fileName = $(this).val().split("\\").pop();
    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
});

$("table a[data-sort]").each(function() {
    const a = $(this);
    a.attr("href", "javascript:void(0)");
    const sortInput = $("#Query_Sort");
    const currentSort = sortInput.val();
    const sortKey = a.data("sort");
    if (currentSort.startsWith(sortKey)) {
        const desc = currentSort.endsWith("_desc");
        a.text(a.text() + (desc ? "↑" : "↓"));
    }

    a.on("click", function() {
        sortInput.val(currentSort === sortKey ? sortKey + "_desc" : sortKey);
        $("#fm-filter").submit();
    });
});