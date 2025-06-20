// Dinamik işlemler için JS kodları buraya yazılacak 

// Kartlara giriş animasyonu
window.addEventListener('DOMContentLoaded', () => {
    const cards = document.querySelectorAll('.card, .card-item');
    cards.forEach((card, i) => {
        card.style.opacity = 0;
        card.style.transform = 'translateY(40px) scale(0.98)';
        setTimeout(() => {
            card.style.transition = 'opacity 0.7s cubic-bezier(.77,0,.18,1), transform 0.7s cubic-bezier(.77,0,.18,1)';
            card.style.opacity = 1;
            card.style.transform = 'translateY(0) scale(1)';
        }, 120 + i * 120);
    });

    // Butonlara dalga efekti
    document.querySelectorAll('.btn').forEach(btn => {
        btn.addEventListener('mouseenter', function(e) {
            btn.classList.add('btn-animate');
        });
        btn.addEventListener('mouseleave', function(e) {
            btn.classList.remove('btn-animate');
        });
    });

    // Hamburger menü aç/kapa
    const menuToggle = document.querySelector('.menu-toggle');
    const menu = document.getElementById('mainMenu');
    if(menuToggle && menu) {
        menuToggle.addEventListener('click', function() {
            menu.classList.toggle('open');
        });
    }

    // Admin paneli için açılır alt menü (submenu)
    document.querySelectorAll('.has-submenu .submenu-toggle').forEach(toggle => {
        toggle.addEventListener('click', function(e) {
            e.preventDefault();
            const parent = this.closest('.has-submenu');
            parent.classList.toggle('open');
        });
    });

    // Admin paneli hamburger menü aç/kapa
    const adminMenuToggle = document.querySelector('.menu-toggle');
    const adminMenu = document.getElementById('adminMenu');
    if(adminMenuToggle && adminMenu) {
        adminMenuToggle.addEventListener('click', function() {
            adminMenu.classList.toggle('open');
        });
    }
}); 