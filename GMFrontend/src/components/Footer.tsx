import logoSmall from "../assets/logo-small.png";

function Footer() {
  return (
    <footer className="text-center text-lg-start bg-body-tertiary text-muted fs-6">
      <div className="text-center p-4">
        Logo Designed by:&nbsp;{" "}
        <a
          className="text-reset fw-bold footer-link"
          href="https://www.freepik.com"
          target="_blank"
        >
          Freepik
        </a>
        <a
          href="https://www.freepik.com/icon/movie_4831192"
          target="_blank"
          title="Logo link"
        >
          <img
            src={logoSmall}
            alt="Logo"
            width="22"
            height="22"
            className="d-inline-block align-text-top ms-1"
          />
        </a>
      </div>
    </footer>
  );
}

export default Footer;
