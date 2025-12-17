document.getElementById('registerForm').addEventListener('submit', function(event) {
    // Updated on Dec 17, 2025
    event.preventDefault();

    const name = document.getElementById('name').value.trim();
    const email = document.getElementById('email').value.trim();
    const genderEls = document.getElementsByName('gender');
    const course = document.getElementById('course').value;
    const terms = document.getElementById('terms').checked;
    const errorMessage = document.getElementById('errorMessage');
    const successMessage = document.getElementById('successMessage');
    const result = document.getElementById('result');

    errorMessage.textContent = '';
    successMessage.style.display = 'none';
    result.style.display = 'none';

    // Name validation
    if (name.length === 0) {
        errorMessage.textContent = 'Name should not be empty.';
        return;
    }

    // Email validation
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
        errorMessage.textContent = 'Please enter a valid email.';
        return;
    }

    // Gender validation
    let selectedGender = '';
    for (let i = 0; i < genderEls.length; i++) {
        if (genderEls[i].checked) {
            selectedGender = genderEls[i].value;
            break;
        }
    }
    if (!selectedGender) {
        errorMessage.textContent = 'Please select your gender.';
        return;
    }

    // Course validation
    if (!course) {
        errorMessage.textContent = 'Please select a course.';
        return;
    }

    // Terms validation
    if (!terms) {
        errorMessage.textContent = 'You must accept the Terms & Conditions.';
        return;
    }

    
    successMessage.textContent = 'Registration successful!';
    successMessage.style.display = 'block';

    result.innerHTML = `
        <h3>Submitted Data</h3>
        <p><strong>Name:</strong> ${escapeHtml(name)}</p>
        <p><strong>Email:</strong> ${escapeHtml(email)}</p>
        <p><strong>Gender:</strong> ${escapeHtml(selectedGender)}</p>
        <p><strong>Course:</strong> ${escapeHtml(course)}</p>
        <p><strong>Terms:</strong> Accepted</p>
    `;
    result.style.display = 'block';

    // Save student data to localStorage for the next page
    const student = { name, email, gender: selectedGender, course };
    try {
        localStorage.setItem('studentData', JSON.stringify(student));
    } catch (e) {
        console.warn('Could not save to localStorage', e);
    }

    // Show Next button and attach navigation
    const nextBtn = document.getElementById('nextBtn');
    if (nextBtn) {
        nextBtn.style.display = 'inline-block';
        nextBtn.onclick = function() {
            window.location.href = 'log.html';
        };
    }
});


function escapeHtml(text) {
    return text
        .replace(/&/g, '&amp;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;')
        .replace(/"/g, '&quot;')
        .replace(/'/g, '&#039;');
}
