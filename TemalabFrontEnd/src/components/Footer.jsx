import "../App.css";

export default function Footer() {
  return (
    <>
      <footer className="text-center text-lg-start container-fluid">
        <section>
          <div className="row mt-3 justify-content-center">
            <div className="col-md-5 col-lg-5 col-xl-5 mt-3 text-center">
              <p>
                <a href="mailto:temalab@gmail.com">@ temalab@gmail.com</a>
              </p>
              <p>
                <i className="fas fa-envelope mr-3"></i> ☏ +36 1 2345678
              </p>
            </div>

            <div className="col-md-2 col-lg-2 col-xl-2 mt-1 text-center">
              <img
                src="logorestaurant-resizedForFooter.png"
                className="footerlogo"
              />
            </div>

            <div className="col-md-5 col-lg-5 col-xl-5 mt-3 text-center">
              <p>
                <i className="fas fa-home mr-3"></i>{" "}
                <a href="https://facebook.com"><img src="/facebook.svg"></img> Facebook</a>
              </p>
              <p>
                <i className="fas fa-envelope mr-3"></i>{" "}
                <a href="https://instagram.com"><img src="/instagram.svg"></img> Instagram</a>
              </p>
            </div>
          </div>
        </section>

        <div
          className=" row text-center p-1 mt-1"
          style={{ backgroundColor: "rgba(0, 0, 0, 0.2)" }}
        >
          <div>© 2024 Témalabor | All rights reserved</div>
        </div>
      </footer>
    </>
  );
}