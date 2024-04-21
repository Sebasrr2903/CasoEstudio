// Función asincrónica para crear un comentario
async function crearComentario(comentarioData) {
    try {
        const response = await fetch('https://localhost:44302/api/comentarios', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            mode: 'cors',
            body: JSON.stringify(comentarioData)
        });

        if (!response.ok) {
            throw new Error('Error al crear el comentario');
        }

        // Obtener el ID del comentario creado desde la respuesta
        const idComentario = await response.text();
        return parseInt(idComentario); // Convertir a entero y devolver
    } catch (error) {
        console.error('Error al crear el comentario:', error);
        throw error; // Propagar el error para que sea manejado por el llamador
    }
}

// Función asincrónica para asignar un comentario a un artículo
async function asignarComentarioAlArticulo(idArticulo, idComentario) {
    try {
        const response = await fetch(`https://localhost:44302/api/articulos/${idArticulo}/addcomment`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            mode: 'cors',
            body: JSON.stringify({ idComment: idComentario })
        });

        if (!response.ok) {
            throw new Error('Error al asignar el comentario al artículo');
        }

        const data = await response.json();
        return data;
    } catch (error) {
        console.error('Error al asignar el comentario al artículo:', error);
        throw error; // Propagar el error para que sea manejado por el llamador
    }
}

// Ejemplo de uso de las funciones asincrónicas
$('#submitButton').click(async function () {
    let comentarioData = {
        fecha: new Date().toISOString(),
        comment: $('#comentarioInput').val()
    };

    try {
        const idComentario = await crearComentario(comentarioData);
        console.log('Comentario creado con éxito, ID:', idComentario);

        let idArticulo = $(this).data('articulo-id');

        const comentarioAsignado = await asignarComentarioAlArticulo(idArticulo, idComentario);
        console.log('Comentario asignado con éxito al artículo:', comentarioAsignado);

        // Aquí puedes realizar acciones adicionales si es necesario
    } catch (error) {
        // Manejar cualquier error ocurrido en la cadena de promesas
        console.error('Error:', error);
    }
});