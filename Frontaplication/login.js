document.getElementById('loginForm').addEventListener('submit', async function(e) {
    e.preventDefault();
    
    const formData = {
        username: document.getElementById('username').value,
        password: document.getElementById('password').value
    };
 
    try {
        const response = await fetch('https://localhost:7250/api/Login/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(formData)
        });
 
        if (response.ok) {
            const data = await response.json();
            localStorage.setItem('token', data.token);
            window.location.href = 'table.html';
        } else {
            alert('Credenciales inválidas');
        }
    } catch (error) {
        alert('Error de conexión');
        console.error(error);
    }
 });