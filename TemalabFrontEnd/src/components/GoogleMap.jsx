export default function GoogleMap(props){

  console.log(props.location)
  const ujcim = props.location?.replace(/ /g, '+')
  console.log(ujcim)
  
  return(
    <>
      <iframe
        height="400"
        width="100%"
        loading="lazy"
        src={"https://www.google.com/maps/embed/v1/place?q=" + ujcim +"&key=AIzaSyAkCFbU5vtVRjOpRh77Z4TBEn-zY8i2X_4"}>
      </iframe>
    </>
  )
}