async function cargarDatos() {
    const tableBody = document.getElementById('tableBody');
    const url = "https://localhost:7250/api/Personaje/getAll";
    
    try {
        const response = await fetch(url);
        const data = await response.json();
        
        if (response.ok) {
            tableBody.innerHTML = data.map(personaje => `
                <tr>
                    <td>${personaje.idPersonaje}</td>
                    <td>${personaje.idAnime}</td>
                    <td>${personaje.nombre}</td>
                    <td>${personaje.descripcion}</td>
                    <td>${personaje.imagenUrl}</td>
                    <td>
                        <button onclick="editarPersonaje(${personaje.idPersonaje})">Editar</button>
                        <button onclick="eliminarPersonaje(${personaje.idPersonaje})">Eliminar</button>
                    </td>
                </tr>
            `).join('');
        } else {
            tableBody.innerHTML = '<tr><td colspan="6">Error al cargar datos</td></tr>';
        }
    } catch (error) {
        tableBody.innerHTML = '<tr><td colspan="6">Error de conexión</td></tr>';
        console.error('Error:', error);
    }
}

async function eliminarPersonaje(id) {
    if (confirm('¿Estás seguro de eliminar este personaje?')) {
        try {
            const response = await fetch(`https://localhost:7250/api/Personaje/${id}`, {
                method: 'DELETE'
            });
            
            if (response.ok) {
                alert('Personaje eliminado correctamente');
                cargarDatos();
            } else {
                alert('Error al eliminar personaje');
            }
        } catch (error) {
            alert('Error de conexión');
            console.error('Error:', error);
        }
    }
}

function editarPersonaje(id) {
    window.location.href = `editar.html?id=${id}`;
}

document.addEventListener('DOMContentLoaded', cargarDatos);