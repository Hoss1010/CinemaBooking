// admin.js

document.addEventListener('DOMContentLoaded', function () {
    const deleteButtons = document.querySelectorAll('.btn-delete');

    deleteButtons.forEach(btn => {
        btn.addEventListener('click', function (e) {
            const confirmDelete = confirm("Are you sure you want to delete this item?");
            if (!confirmDelete) {
                e.preventDefault();
            }
        });
    });

    console.log("Admin JS loaded.");
});
