// Film tablosu için frontend arama ve sayfalama
const pageSize = 10;
let currentPage = 1;
let allRows = [];
let filteredRows = [];

window.addEventListener('DOMContentLoaded', () => {
    const table = document.getElementById('filmTable');
    const tbody = table.querySelector('tbody');
    allRows = Array.from(tbody.querySelectorAll('tr'));
    filteredRows = allRows.slice();
    renderPage();
    renderPagination();
});

function filterFilms() {
    const search = document.getElementById('filmSearch').value.toLowerCase();
    filteredRows = allRows.filter(row => {
        const filmCell = row.children[1].textContent.toLowerCase();
        return filmCell.includes(search);
    });
    currentPage = 1;
    renderPage();
    renderPagination();
}

function renderPage() {
    const table = document.getElementById('filmTable');
    const tbody = table.querySelector('tbody');
    tbody.innerHTML = '';
    const start = (currentPage - 1) * pageSize;
    const end = start + pageSize;
    filteredRows.slice(start, end).forEach((row, i) => {
        // Sıra numarasını güncelle
        row.children[0].textContent = start + i + 1;
        tbody.appendChild(row);
    });
}

function renderPagination() {
    const pagination = document.getElementById('filmPagination');
    pagination.innerHTML = '';
    const pageCount = Math.ceil(filteredRows.length / pageSize);
    for (let i = 1; i <= pageCount; i++) {
        const btn = document.createElement('button');
        btn.textContent = i;
        if (i === currentPage) btn.classList.add('active');
        btn.onclick = () => {
            currentPage = i;
            renderPage();
            renderPagination();
        };
        pagination.appendChild(btn);
    }
} 