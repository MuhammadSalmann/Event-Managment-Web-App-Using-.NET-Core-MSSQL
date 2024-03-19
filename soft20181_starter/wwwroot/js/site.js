const initSlider = () => {
    const imageList = document.querySelector(".slider-trending .image-list");
    const slideButtons = document.querySelectorAll(".slider-trending .slide-button");
    const sliderScrollbar = document.querySelector(".trending .slider-scrollbar");
    const scrollbarThumb = sliderScrollbar.querySelector(".scrollbar-thumb");
    const maxScrollLeft = imageList.scrollWidth - imageList.clientWidth;

    slideButtons.forEach(button => {
        button.addEventListener("click", () => {
            const direction = button.id === "prev-slide" ? -1 : 1;
            const scrollAmount = imageList.clientWidth * direction;
            imageList.scrollBy({ left: scrollAmount, behavior: "smooth" });
        });
    });

    const handleSlideButtons = () => {
        slideButtons[0].style.display = imageList.scrollLeft <= 0 ? "none" : "block";
        slideButtons[1].style.display = imageList.scrollLeft >= maxScrollLeft ? "none" : "block";
    }

    const updateScrollThumbPosition = () => {
        const scrollPosition = imageList.scrollLeft;
        const thumbPosition = (scrollPosition / maxScrollLeft) * (sliderScrollbar.clientWidth - scrollbarThumb.offsetWidth);
        scrollbarThumb.style.left = `${thumbPosition}px`;
    }

    imageList.addEventListener("scroll", () => {
        handleSlideButtons();
        updateScrollThumbPosition();
    });
}

window.addEventListener("load", initSlider);


document.addEventListener('DOMContentLoaded', function () {
    const checkbox = document.getElementById('check');
    const body = document.body;
    const searchOverlay = document.querySelector('.search-overlay');
    const searchInput = document.getElementById('search-input');
    const closeSearchButton = document.getElementById('close-search');


    checkbox.addEventListener('change', function () {
        if (checkbox.checked) {
            body.classList.add('search-active');
            searchOverlay.style.opacity = '1';
            searchOverlay.style.pointerEvents = 'auto';
            searchInput.focus();
            closeSearchButton.style.display = 'block';

            sessionStorage.setItem('currentPageUrl', window.location.href);
        } else {
            body.classList.remove('search-active');
            searchOverlay.style.opacity = '0';
            searchOverlay.style.pointerEvents = 'none';
            closeSearchButton.style.display = 'none';
        }
    });
