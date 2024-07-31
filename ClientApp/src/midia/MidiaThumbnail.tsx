import React from "react";
import { FunctionField, ImageField } from "react-admin";
import { IMidia } from "./IMidia";

export const MidiaThumbnail = ({ midia }: { midia: IMidia }) => {
  return midia.tipo === "I" ? (
    <ImageField source="imagemUrl" label="Imagem" record={midia} />
  ) : midia.tipo === "V" ? (
    <video width="128" height="96" controls>
      <source src={midia.imagemUrl} type="video/mp4" />
    </video>
  ) : (
    <ImageField source="arquivo" label="RSS" record={midia} />
  );
};
