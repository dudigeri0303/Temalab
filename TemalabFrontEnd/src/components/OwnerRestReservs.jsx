export default function OwnerRestReservs({data}){

    return(
        <>
            <div className="container">
                <div className="div-card">
                    <div className="row">
                        <div className="row col-12 col-md-4">
                            <div className="col-12">
                                <p className="card-Altext">{data.userName}</p>
                            </div>
                            <div className="col-12">
                                <p className="card-Altext">{data.phoneNumber}</p>
                            </div>
                            <div className="col-12">
                                <p className="card-Altext">{data.numOfPeople} Fő</p>
                            </div>
                        </div>
                        <div className="row col-12 col-md-4">
                            <div className="col-12">
                                <p className="card-Altext">{data.dateTime}</p>
                            </div>
                            <div className="col-12">
                                <p className="card-Altext">{data.lenght} Óra</p>
                            </div>
                        </div>
                        <p className="card-Altext col-12 col-md-4">{data.comment}</p>
                    </div>
                </div>
            </div>
        </>
    )
}