Shader "Custom/InvisibleMask" {
  SubShader {
    Tags { "Queue"="Transparent+1" }
    Pass {
      Blend Zero One
      }
  } 
}