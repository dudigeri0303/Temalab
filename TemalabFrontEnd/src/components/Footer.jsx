import "../App.css";

export default function Footer() {
  return (
    <>
        <footer className="text-center text-lg-start">
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

              <div className="col-md-2 col-lg-2 col-xl-2 mt-1">
                <img
                  src="logorestaurant-resizedForFooter.png"
                  style={{ width: "90%" }}
                />
              </div>

              <div className="col-md-5 col-lg-5 col-xl-5 mt-3 text-center">
                <p>
                  <i className="fas fa-home mr-3"></i>{" "}
                  <a href="https://facebook.com">ⓕ Facebook</a>
                </p>
                <p>
                  <i className="fas fa-envelope mr-3"></i>{" "}
                  <a href="https://instagram.com">[◉°] Instagram</a>
                </p>
              </div>
            </div>
          </section>

          <div
            className="text-center p-1 mt-1"
            style={{ backgroundColor: "rgba(0, 0, 0, 0.2)" }}
          >
            © 2024 Témalabor | All rights reserved
          </div>
        </footer>
    </>
  );
}