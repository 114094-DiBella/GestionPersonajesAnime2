document.getElementById('loginForm').addEventListener('submit', async function(e) {
    e.preventDefault();
    const url = "https://localhost:7250/api/Login/login";
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    
    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                username: username,
                password: password
            })
        });

        const data = await response.json();
        
        if (response.ok) {
            alert('Login exitoso!');
            // Aquí podrías guardar el token si el backend lo envía
            // localStorage.setItem('token', data.token);
            // window.location.href = 'dashboard.html';
            window.location.href = 'table.html';
        } else {
            alert(data.message || 'Error en el login');
        }
    } catch (error) {
        alert('Error de conexión');
        console.error('Error:', error);
    }
});