// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function () {
    function handleScroll() {
        let animatedElements = document.querySelectorAll(".animated");
        let windowHeight = window.innerHeight;

        animatedElements.forEach(element => {
            let position = element.getBoundingClientRect().top;

            if (position < windowHeight - 100) { // Element is in view
                element.classList.add("show");
            }
        });
    }

    // Run on page load
    handleScroll();

    // Run on scroll
    window.addEventListener("scroll", handleScroll);

    // Add click animation to cards
    document.querySelectorAll(".card").forEach(card => {
        card.addEventListener("click", function () {
            this.classList.add("animated-click");
            setTimeout(() => this.classList.remove("animated-click"), 300); // Reset after animation
        });
    });
});

