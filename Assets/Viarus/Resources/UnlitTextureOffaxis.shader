// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Copyright 2016 Viarus. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

Shader "NAR/UnlitTextureOffaxis" {
 Properties {
   _Color ("Color", Color) = (1,1,1,1)
   _MainTex ("Texture", 2D) = "white" {}
 }
 SubShader {
   Tags { "RenderType"="Opaque" }
   Cull Off
   Blend Off
   ZTest Always
   ZWrite Off
   Lighting Off
   Fog {Mode Off}

   Pass {
     CGPROGRAM
     #pragma vertex vert
     #pragma fragment frag

     #include "UnityCG.cginc"

     struct appdata {
       float4 vertex : POSITION;
       float4 color : COLOR;
       float2 uv : TEXCOORD0;
     };

     struct v2f {
       float2 uv : TEXCOORD0;
       float4 color : COLOR;
       float4 vertex : SV_POSITION;
     };

     sampler2D _MainTex;
     float4 _MainTex_ST;
     float4 _Color;

     v2f vert (appdata v) {
       v2f o;
       o.vertex = UnityObjectToClipPos(v.vertex);
       o.color = v.color;
       o.uv = TRANSFORM_TEX(v.uv, _MainTex);
       return o;
     }

     fixed4 frag (v2f i) : COLOR {
		 if (i.uv.x < 0.035 || i.uv.x > 0.965 || i.uv.y < 0.04 || i.uv.y > 0.965) return (1,1,0,0);
       return tex2D(_MainTex, i.uv) * i.color * _Color;
     }
     ENDCG
   }
 }
}
