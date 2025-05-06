import React from "react";
import { Carousel } from "react-bootstrap";
import img1 from "../assets/images/categoriaInfo.jpg";
import img2 from "../assets/images/categoriaInfo2.jpg";
import img3 from "../assets/images/categoriaInfo4.jpg";
import img4 from "../assets/images/categoriaInfo5.jpg";
import img5 from "../assets/images/categoriaInfo6.jpg";
import img6 from "../assets/images/categoriaInfo7.jpg";

function ImageCarousel() {
  const images = [img1, img2, img3, img4, img5, img6];

  return (
    <div className="my-5 d-flex justify-content-center">
      <Carousel
        controls={false}
        indicators={true}
        interval={4000}
        pause="hover"
        className="shadow rounded overflow-hidden"
        style={{ width: "700px" }}
      >
        {images.map((img, index) => (
          <Carousel.Item key={index}>
            <img
              src={img}
              alt={`Slide ${index + 1}`}
              className="d-block w-100"
              style={{ height: "400px", objectFit: "cover" }}
            />
          </Carousel.Item>
        ))}
      </Carousel>
    </div>
  );
}

export default ImageCarousel;
