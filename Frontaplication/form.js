document.getElementById('dataForm').addEventListener('submit', async function(e) {
    e.preventDefault();
    
    // Obtener valores
    const idAnime = document.getElementById('idAnime').value;
    const nombre = document.getElementById('nombre').value.trim();
    const descripcion = document.getElementById('descripcion').value.trim();
    const imagenUrl = document.getElementById('imagenUrl').value.trim();
 
    // Validaciones
    if (idAnime <= 0) {
        alert('El ID del anime debe ser un número positivo');
        return;
    }
 
    if (nombre.length < 2 || nombre.length > 100) {
        alert('El nombre debe tener entre 2 y 100 caracteres');
        return;
    }
 
    if (descripcion.length < 10) {
        alert('La descripción debe tener al menos 10 caracteres');
        return;
    }
 
    //if (!isValidUrl(imagenUrl)) {
    //    alert('Por favor ingrese una URL válida para la imagen');
    //    return;
    //}
 
    const formData = {
        idAnime: parseInt(idAnime),
        nombre,
        descripcion,
        imagenUrl
    };
 
    // Enviar formulario
    const token = localStorage.getItem('token');
    if (!token) {
        alert('No hay sesión activa');
        window.location.href = 'login.html';
        return;
    }
 
    try {
        const response = await fetch('https://localhost:7250/api/Personaje/create', {
            method: 'POST',
            headers: { 
               'Content-Type': 'application/json',
               'Authorization': `Bearer ${token}` //Enviando el token
            },
            body: JSON.stringify(formData)
        });
        
        if (response.ok) {
            alert('Personaje creado correctamente');
            window.location.href = 'table.html';
        } else {
            alert('Error al crear personaje');
        }
    } catch (error) {
        alert('Error de conexión');
        console.error('Error:', error);
    }
 });
 
 function isValidUrl(string) {
    try {
        new URL(string);
        return true;
    } catch (_) {
        return false;
    }
 }