// editar.js
document.addEventListener('DOMContentLoaded', async () => {
    const params = new URLSearchParams(window.location.search);
    const id = params.get('id');
    const token = localStorage.getItem('token');

    if (!token) {
        window.location.href = 'login.html';
        return;
    }

    try {
        const response = await fetch(`https://localhost:7250/api/Personaje/getById/${id}`, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });

        if (response.ok) {
            const personaje = await response.json();
            document.getElementById('idAnime').value = personaje.idAnime;
            document.getElementById('nombre').value = personaje.nombre;
            document.getElementById('descripcion').value = personaje.descripcion;
            document.getElementById('imagenUrl').value = personaje.imagenUrl;
        }
    } catch (error) {
        console.error('Error:', error);
    }
});

document.getElementById('editForm').addEventListener('submit', async (e) => {
    e.preventDefault();
    const params = new URLSearchParams(window.location.search);
    const id = params.get('id');
    const token = localStorage.getItem('token');

    const formData = {
        idAnime: parseInt(document.getElementById('idAnime').value),
        nombre: document.getElementById('nombre').value.trim(),
        descripcion: document.getElementById('descripcion').value.trim(),
        imagenUrl: document.getElementById('imagenUrl').value.trim()
    };

    try {
        const response = await fetch(`https://localhost:7250/api/Personaje/update/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify(formData)
        });

        if (response.ok) {
            alert('Personaje actualizado correctamente');
            window.location.href = 'table.html';
        } else {
            alert('Error al actualizar el personaje');
        }
    } catch (error) {
        console.error('Error:', error);
        alert('Error de conexión');
    }
});