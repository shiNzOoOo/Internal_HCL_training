document.addEventListener('DOMContentLoaded', function() {
    const form = document.querySelector('form');
    if (form) {
        form.addEventListener('submit', function(e) {
            e.preventDefault();
            const firstname = document.getElementById('text').value;
            window.location.href = 'project.html?firstname=' + encodeURIComponent(firstname);
        });
    }
});

