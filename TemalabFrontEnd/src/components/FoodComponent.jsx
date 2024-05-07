export default function FoodComponent({data}){
    
    const deletefood = async() => {
        const myHeaders = new Headers();

        const requestOptions = {
        method: "DELETE",
        headers: myHeaders,
        credentials: 'include',
        xhrFields: { withCredentials: true},
        redirect: "follow"
        };

        try {
            const response = await fetch("https://localhost:7114/api/Food/deleteFoodByID?foodId=" + data.id, requestOptions);
            const result = await response.text();
            console.log(result);
            //window.location.reload();
          } catch (error) {
            console.error(error);
          }
      
          window.location.reload()
    }
    
    return(
        <>
            <div className="d-flex justify-content-between">
                <p>{data.name}</p>
                <p>{data.price} Ft</p>
                <button type="submit" onClick={deletefood}>Törlés</button>
            </div>
        </>
    )
}