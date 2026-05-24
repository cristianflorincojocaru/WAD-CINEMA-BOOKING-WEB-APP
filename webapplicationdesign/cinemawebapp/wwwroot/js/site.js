document.addEventListener('DOMContentLoaded', () => {
    document.querySelectorAll('[data-animate] > *').forEach((el, i) => {
        el.style.animationDelay = `${i * 60}ms`;
    });
});