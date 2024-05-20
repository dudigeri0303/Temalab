import { useEffect, useState } from "react";

export default function FoodComponent({data}){

    const [isImage,setIsImage] = useState(false);

    useEffect(() => {
        if(data.image !== ""){
            setIsImage(true)
        }
    })
    
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
        } catch (error) {
            console.error(error);
        }
    
        window.location.reload()
    }

    const [img,setImg] = useState()

    const addimg = (event) => {
        setImg(event.target.files[0])
    }

    const imgokay = async() => {
        if (!img) {
            console.error('No file selected');
            return;
        }

        console.log(img);

        let formdata = new FormData();
        formdata.append('imageFile', img);

        for (let [key, value] of formdata.entries()) {
            console.log(`${key}:`, value);
        }

        const requestOptions = {
            method: "PUT",
            credentials: 'include',
            redirect: "follow",
            body: formdata,
        };

        try {
            const response = await fetch(`https://localhost:7114/api/Food/addImageToFood?foodId=${data.id}`, requestOptions);
            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(`Error: ${response.status} - ${errorText}`);
            }
            const result = await response.text();
            console.log(result);
        } catch (error) {
            console.error(error);
        }
    };
    
    return(
        <>
            <div className="row div-card mb-3">
                <div className="col-12 col-md-4 mt-3 mb-3 row">
                    <div className="col-6">
                        {isImage && <img className="imgsizing" src={"data:image/jpeg;base64," + data.image}/>}
                    </div>
                    <div className="col-6">
                        <h5 className="text-white">{data.name}</h5>
                        <p className="fst-italic text-white">{data.description}</p>
                    </div>
                </div>
                <div className="col-12 col-md-4 d-flex justify-content-center">
                    <p className="text-white">{data.price} Ft</p>
                </div>
                <div className="d-flex col-12 col-md-4 mb-md-0 mb-3">
                    <div className="d-flex flex-column">
                        <div>
                            <button type="submit" className="btnstyle p-2 mb-2" onClick={deletefood}>Törlés</button>
                        </div>
                        <input className="inputimg" onChange={addimg} type="file"/>
                        <div>
                            <button className="btnstyle p-2 mt-2" onClick={imgokay}>Kép feltöltése</button>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}