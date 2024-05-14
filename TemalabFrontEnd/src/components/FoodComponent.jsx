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
            <div className="row div-card mb-3">
                <div className="col-6 col-md-4 mt-3">
                    <h5 className="text-white">{data.name}</h5>
                    <p className="fst-italic text-white">{data.description}</p>
                </div>
                <div className="col-6 col-md-4 d-flex justify-content-center">
                    <p className="text-white">{data.price} Ft</p>
                </div>
                <div className="d-flex align-items-center justify-content-end col-12 col-md-4">
                    <button type="submit" className="btnstyle p-2" onClick={deletefood}>Törlés</button>
                </div>
            </div>
        </>
    )
}