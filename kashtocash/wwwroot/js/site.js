// Theme Toggle
document.addEventListener('DOMContentLoaded', function () {
    const toggleBtn = document.getElementById('themeToggle');
    const body = document.body;

    // Check if dark mode was previously set
    if (localStorage.getItem('theme') === 'dark') {
        body.classList.add('dark-theme');
        toggleBtn.innerHTML = '<i class="fas fa-sun"></i> Light Mode';
    }

    toggleBtn.addEventListener('click', () => {
        body.classList.toggle('dark-theme');
        const isDark = body.classList.contains('dark-theme');

        // Save preference
        localStorage.setItem('theme', isDark ? 'dark' : 'light');

        // Toggle button icon and text
        toggleBtn.innerHTML = isDark
            ? '<i class="fas fa-sun"></i> Light Mode'
            : '<i class="fas fa-moon"></i> Dark Mode';
    });
});
