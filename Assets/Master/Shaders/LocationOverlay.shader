// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32993,y:32720,varname:node_3138,prsc:2|emission-7241-RGB,alpha-1023-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32504,y:32628,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Slider,id:2695,x:32260,y:33104,ptovrint:False,ptlb:Max Opacity,ptin:_MaxOpacity,varname:node_2695,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Sin,id:2629,x:32224,y:33218,varname:node_2629,prsc:2|IN-1712-OUT;n:type:ShaderForge.SFN_Time,id:8879,x:31880,y:33245,varname:node_8879,prsc:2;n:type:ShaderForge.SFN_Slider,id:1143,x:32260,y:33001,ptovrint:False,ptlb:Min Opacity,ptin:_MinOpacity,varname:_MaxOpacity_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Lerp,id:6700,x:32666,y:33022,varname:node_6700,prsc:2|A-1143-OUT,B-2695-OUT,T-1189-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7373,x:31880,y:33189,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_7373,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_Multiply,id:1712,x:32050,y:33218,varname:node_1712,prsc:2|A-7373-OUT,B-8879-T;n:type:ShaderForge.SFN_RemapRange,id:1189,x:32404,y:33218,varname:node_1189,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-2629-OUT;n:type:ShaderForge.SFN_Tex2d,id:2225,x:32344,y:33441,ptovrint:False,ptlb:Position Map,ptin:_PositionMap,varname:node_2225,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:61f57859a9948054e87689034b8a4e8b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1023,x:32802,y:33240,varname:node_1023,prsc:2|A-6700-OUT,B-698-OUT;n:type:ShaderForge.SFN_OneMinus,id:698,x:32542,y:33441,varname:node_698,prsc:2|IN-2225-G;proporder:7241-2695-1143-7373-2225;pass:END;sub:END;*/

Shader "Shader Forge/LocationOverlay" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _MaxOpacity ("Max Opacity", Range(0, 1)) = 1
        _MinOpacity ("Min Opacity", Range(0, 1)) = 0.5
        _Speed ("Speed", Float ) = 3
        _PositionMap ("Position Map", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _MaxOpacity;
            uniform float _MinOpacity;
            uniform float _Speed;
            uniform sampler2D _PositionMap; uniform float4 _PositionMap_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float3 emissive = _Color.rgb;
                float3 finalColor = emissive;
                float4 node_8879 = _Time + _TimeEditor;
                float4 _PositionMap_var = tex2D(_PositionMap,TRANSFORM_TEX(i.uv0, _PositionMap));
                return fixed4(finalColor,(lerp(_MinOpacity,_MaxOpacity,(sin((_Speed*node_8879.g))*0.5+0.5))*(1.0 - _PositionMap_var.g)));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
