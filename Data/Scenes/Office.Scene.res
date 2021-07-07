﻿<root dataType="Struct" type="Duality.Resources.Scene" id="129723834">
  <assetInfo />
  <globalGravity dataType="Struct" type="Duality.Vector2">
    <X dataType="Float">0</X>
    <Y dataType="Float">33</Y>
  </globalGravity>
  <serializeObj dataType="Array" type="Duality.GameObject[]" id="427169525">
    <item dataType="Struct" type="Duality.GameObject" id="1256118317">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="460535071">
        <_items dataType="Array" type="Duality.Component[]" id="1678736238" length="8">
          <item dataType="Struct" type="Duality.Components.Transform" id="1313395535">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">1256118317</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">640</X>
              <Y dataType="Float">360</Y>
              <Z dataType="Float">-500</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">640</X>
              <Y dataType="Float">360</Y>
              <Z dataType="Float">-500</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Camera" id="2802504794">
            <active dataType="Bool">true</active>
            <clearColor dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">0</A>
              <B dataType="Byte">0</B>
              <G dataType="Byte">0</G>
              <R dataType="Byte">255</R>
            </clearColor>
            <farZ dataType="Float">10000</farZ>
            <focusDist dataType="Float">500</focusDist>
            <gameobj dataType="ObjectRef">1256118317</gameobj>
            <nearZ dataType="Float">50</nearZ>
            <priority dataType="Int">0</priority>
            <projection dataType="Enum" type="Duality.Drawing.ProjectionMode" name="Perspective" value="1" />
            <renderSetup dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderSetup]]">
              <contentPath dataType="String">Data\Renderer\OfficeSetup.RenderSetup.res</contentPath>
            </renderSetup>
            <renderTarget dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderTarget]]" />
            <shaderParameters dataType="Struct" type="Duality.Drawing.ShaderParameterCollection" id="3338390462" custom="true">
              <body />
            </shaderParameters>
            <targetRect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">1</H>
              <W dataType="Float">1</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </targetRect>
            <visibilityMask dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="All" value="4294967295" />
          </item>
          <item dataType="Struct" type="Duality.Components.VelocityTracker" id="3327252784">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1256118317</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.SoundListener" id="3288770844">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1256118317</gameobj>
          </item>
          <item dataType="Struct" type="FNaFMP.Office.CameraViewer" id="1065128514">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1256118317</gameobj>
            <lastTime dataType="Int">0</lastTime>
            <started dataType="Bool">false</started>
          </item>
          <item dataType="Struct" type="FNaFMP.Office.DisplayController" id="459163443">
            <active dataType="Bool">true</active>
            <direction dataType="Float">0</direction>
            <gameobj dataType="ObjectRef">1256118317</gameobj>
            <started dataType="Bool">true</started>
          </item>
          <item dataType="Struct" type="FNaFMP.Utility.HudRenderer" id="737527849">
            <active dataType="Bool">true</active>
            <font dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Font]]" />
            <gameobj dataType="ObjectRef">1256118317</gameobj>
          </item>
        </_items>
        <_size dataType="Int">7</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2827722272" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="661882005">
            <item dataType="Type" id="3757206646" value="Duality.Components.Transform" />
            <item dataType="Type" id="3238416666" value="Duality.Components.Camera" />
            <item dataType="Type" id="264927126" value="Duality.Components.VelocityTracker" />
            <item dataType="Type" id="2989616890" value="Duality.Components.SoundListener" />
            <item dataType="Type" id="1232654006" value="FNaFMP.Office.CameraViewer" />
            <item dataType="Type" id="3404768858" value="FNaFMP.Office.DisplayController" />
            <item dataType="Type" id="1108852182" value="FNaFMP.Utility.HudRenderer" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2244243144">
            <item dataType="ObjectRef">1313395535</item>
            <item dataType="ObjectRef">2802504794</item>
            <item dataType="ObjectRef">3327252784</item>
            <item dataType="ObjectRef">3288770844</item>
            <item dataType="ObjectRef">1065128514</item>
            <item dataType="ObjectRef">459163443</item>
            <item dataType="ObjectRef">737527849</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1313395535</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="908527519">wBTbM7YJFky6aaOHEQLq3A==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Camera</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="194760272">
      <active dataType="Bool">true</active>
      <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="2333233398">
        <_items dataType="Array" type="Duality.GameObject[]" id="3261580512" length="4" />
        <_size dataType="Int">0</_size>
      </children>
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2586107418">
        <_items dataType="Array" type="Duality.Component[]" id="2116499396" length="8">
          <item dataType="Struct" type="Duality.Components.Transform" id="252037490">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">194760272</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="1663379552">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">194760272</gameobj>
            <offset dataType="Float">300</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">720</H>
              <W dataType="Float">1600</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Office\office_def.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">0</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="4229924108">
            <active dataType="Bool">true</active>
            <animDuration dataType="Float">0</animDuration>
            <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="FixedSingle" value="4" />
            <animTime dataType="Float">0</animTime>
            <customFrameSequence />
            <firstFrame dataType="Int">0</firstFrame>
            <frameCount dataType="Int">1</frameCount>
            <gameobj dataType="ObjectRef">194760272</gameobj>
            <paused dataType="Bool">true</paused>
          </item>
          <item dataType="Struct" type="FNaFMP.Office.CameraRenderer" id="3780257928">
            <active dataType="Bool">true</active>
            <animator />
            <gameobj dataType="ObjectRef">194760272</gameobj>
            <lastTime dataType="Int">0</lastTime>
            <list dataType="Struct" type="System.Collections.Generic.List`1[[System.Collections.Generic.List`1[[FNaFMP.Office.CameraView]]]]" id="86207104">
              <_items dataType="Array" type="System.Collections.Generic.List`1[[FNaFMP.Office.CameraView]][]" id="2129012124" length="16">
                <item dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Office.CameraView]]" id="1927433668">
                  <_items dataType="Array" type="FNaFMP.Office.CameraView[]" id="106254660" length="4">
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="4055159364">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\1A\1A-none.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots />
                    </item>
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="3932154518">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\1A\1A-all.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Core+Character]]" id="894706638">
                        <_items dataType="Array" type="FNaFMP.Core+Character[]" id="907198928" length="4">
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Freddy" value="1" />
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Bonnie" value="2" />
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Chica" value="3" />
                        </_items>
                        <_size dataType="Int">3</_size>
                      </robots>
                    </item>
                  </_items>
                  <_size dataType="Int">2</_size>
                </item>
                <item dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Office.CameraView]]" id="521480598">
                  <_items dataType="Array" type="FNaFMP.Office.CameraView[]" id="1136008782" length="4">
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="1576083152">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\1B\1B-none.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots />
                    </item>
                  </_items>
                  <_size dataType="Int">1</_size>
                </item>
                <item dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Office.CameraView]]" id="4217535616">
                  <_items dataType="Array" type="FNaFMP.Office.CameraView[]" id="671329864">
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="282029164">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">0</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\1C\1C-s0.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Core+Character]]" id="4223506276">
                        <_items dataType="Array" type="FNaFMP.Core+Character[]" id="317604804" length="4">
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Foxy" value="4" />
                        </_items>
                        <_size dataType="Int">1</_size>
                      </robots>
                    </item>
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="3142210614">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\1C\1C-s1.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Core+Character]]" id="2093670566">
                        <_items dataType="Array" type="FNaFMP.Core+Character[]" id="1613652480" length="4">
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Foxy" value="4" />
                        </_items>
                        <_size dataType="Int">1</_size>
                      </robots>
                    </item>
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="2987487544">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">2</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\1C\1C-s2.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Core+Character]]" id="3212128376">
                        <_items dataType="Array" type="FNaFMP.Core+Character[]" id="3583866220" length="4">
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Foxy" value="4" />
                        </_items>
                        <_size dataType="Int">1</_size>
                      </robots>
                    </item>
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="1783584018">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">3</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\1C\1C-s3.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots />
                    </item>
                  </_items>
                  <_size dataType="Int">4</_size>
                </item>
                <item dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Office.CameraView]]" id="1474218018">
                  <_items dataType="Array" type="FNaFMP.Office.CameraView[]" id="1038521490">
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="3344059472">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">0</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\2A\2A-empty.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots />
                    </item>
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="655802734">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">0</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\2A\2A-bonnie.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Core+Character]]" id="1814106402">
                        <_items dataType="Array" type="FNaFMP.Core+Character[]" id="1266524944" length="4">
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Bonnie" value="2" />
                        </_items>
                        <_size dataType="Int">1</_size>
                      </robots>
                    </item>
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="3169913388">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\2A\2A-off.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots />
                    </item>
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="763908882">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">0</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\2A\2A-foxy.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Core+Character]]" id="3672491318">
                        <_items dataType="Array" type="FNaFMP.Core+Character[]" id="3149026144" length="4">
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Foxy" value="4" />
                        </_items>
                        <_size dataType="Int">1</_size>
                      </robots>
                    </item>
                  </_items>
                  <_size dataType="Int">4</_size>
                </item>
                <item dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Office.CameraView]]" id="2058473948">
                  <_items dataType="Array" type="FNaFMP.Office.CameraView[]" id="1682741772" length="4">
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="726193316">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\2B\2B-none.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots />
                    </item>
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="3386426134">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\2B\2B-bonnie.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Core+Character]]" id="1616446190">
                        <_items dataType="Array" type="FNaFMP.Core+Character[]" id="949755984" length="4">
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Bonnie" value="2" />
                        </_items>
                        <_size dataType="Int">1</_size>
                      </robots>
                    </item>
                  </_items>
                  <_size dataType="Int">2</_size>
                </item>
                <item dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Office.CameraView]]" id="1764169982">
                  <_items dataType="Array" type="FNaFMP.Office.CameraView[]" id="1507286182" length="4">
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="1717047808">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\3\3-none.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">false</move>
                      <robots />
                    </item>
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="2985099214">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\3\3-bonnie.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">false</move>
                      <robots dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Core+Character]]" id="137521362">
                        <_items dataType="Array" type="FNaFMP.Core+Character[]" id="2592108368" length="4">
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Bonnie" value="2" />
                        </_items>
                        <_size dataType="Int">1</_size>
                      </robots>
                    </item>
                  </_items>
                  <_size dataType="Int">2</_size>
                </item>
                <item dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Office.CameraView]]" id="1787977016">
                  <_items dataType="Array" type="FNaFMP.Office.CameraView[]" id="2291045744" length="4">
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="3430473020">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\4A\4A-none.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots />
                    </item>
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="2003432342">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\4A\4A-freddy.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Core+Character]]" id="851847958">
                        <_items dataType="Array" type="FNaFMP.Core+Character[]" id="3982652704" length="4">
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Freddy" value="1" />
                        </_items>
                        <_size dataType="Int">1</_size>
                      </robots>
                    </item>
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="929989608">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\4A\4A-chica.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Core+Character]]" id="3462877656">
                        <_items dataType="Array" type="FNaFMP.Core+Character[]" id="1007161772" length="4">
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Chica" value="3" />
                        </_items>
                        <_size dataType="Int">1</_size>
                      </robots>
                    </item>
                  </_items>
                  <_size dataType="Int">3</_size>
                </item>
                <item dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Office.CameraView]]" id="3388823402">
                  <_items dataType="Array" type="FNaFMP.Office.CameraView[]" id="2331649674" length="4">
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="3146988512">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\4B\4B-none.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots />
                    </item>
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="4279872398">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\4B\4B-freddy.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Core+Character]]" id="1530135346">
                        <_items dataType="Array" type="FNaFMP.Core+Character[]" id="2391945168" length="4">
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Freddy" value="1" />
                        </_items>
                        <_size dataType="Int">1</_size>
                      </robots>
                    </item>
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="1383357180">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\4B\4B-chica.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Core+Character]]" id="3247316600">
                        <_items dataType="Array" type="FNaFMP.Core+Character[]" id="2302982508" length="4">
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Chica" value="3" />
                        </_items>
                        <_size dataType="Int">1</_size>
                      </robots>
                    </item>
                  </_items>
                  <_size dataType="Int">3</_size>
                </item>
                <item dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Office.CameraView]]" id="2725417012">
                  <_items dataType="Array" type="FNaFMP.Office.CameraView[]" id="900681332" length="4">
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="326479780">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\5\5-none.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots />
                    </item>
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="3403980566">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\5\5-bonnie.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Core+Character]]" id="531841518">
                        <_items dataType="Array" type="FNaFMP.Core+Character[]" id="1534443088" length="4">
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Bonnie" value="2" />
                        </_items>
                        <_size dataType="Int">1</_size>
                      </robots>
                    </item>
                  </_items>
                  <_size dataType="Int">2</_size>
                </item>
                <item dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Office.CameraView]]" id="3809492358">
                  <_items dataType="Array" type="FNaFMP.Office.CameraView[]" id="3712172990" length="4">
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="4261242896">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\6\black_screen.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">false</move>
                      <robots />
                    </item>
                  </_items>
                  <_size dataType="Int">1</_size>
                </item>
                <item dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Office.CameraView]]" id="1950028208">
                  <_items dataType="Array" type="FNaFMP.Office.CameraView[]" id="3189220408" length="4">
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="4157041260">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\7\7-none.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots />
                    </item>
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="3171999798">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\7\7-freddy.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Core+Character]]" id="2799974054">
                        <_items dataType="Array" type="FNaFMP.Core+Character[]" id="1470397952" length="4">
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Freddy" value="1" />
                        </_items>
                        <_size dataType="Int">1</_size>
                      </robots>
                    </item>
                    <item dataType="Struct" type="FNaFMP.Office.CameraView" id="1382171448">
                      <duration dataType="Float">0</duration>
                      <extra dataType="Int">-1</extra>
                      <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\Camera\View\7\7-chica.Material.res</contentPath>
                      </mat>
                      <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
                      <move dataType="Bool">true</move>
                      <robots dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Core+Character]]" id="1812834424">
                        <_items dataType="Array" type="FNaFMP.Core+Character[]" id="1242019180" length="4">
                          <item dataType="Enum" type="FNaFMP.Core+Character" name="Chica" value="3" />
                        </_items>
                        <_size dataType="Int">1</_size>
                      </robots>
                    </item>
                  </_items>
                  <_size dataType="Int">3</_size>
                </item>
              </_items>
              <_size dataType="Int">11</_size>
            </list>
            <renderer />
            <transform />
          </item>
          <item dataType="Struct" type="FNaFMP.Office.FreddyPoster" id="3461982009">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">194760272</gameobj>
            <limit dataType="Int">0</limit>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">8</H>
              <W dataType="Float">8</W>
              <X dataType="Float">675</X>
              <Y dataType="Float">234</Y>
            </rect>
            <sound dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
              <contentPath dataType="String">Data\Office\FreddyNose.Sound.res</contentPath>
            </sound>
          </item>
          <item dataType="Struct" type="FNaFMP.Office.MovementControl" id="1895485408">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">194760272</gameobj>
            <movements dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[System.Collections.Generic.List`1[[FNaFMP.Office.Movement]]]]" id="3123747560" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="91442732">
                  <item dataType="Enum" type="FNaFMP.Core+Character" name="Freddy" value="1" />
                </keys>
                <values dataType="Array" type="System.Object[]" id="721531830">
                  <item dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Office.Movement]]" id="2061202022">
                    <_items dataType="Array" type="FNaFMP.Office.Movement[]" id="1818176384">
                      <item dataType="Struct" type="FNaFMP.Office.Movement" id="1022652828">
                        <_x003C_From_x003E_k__BackingField dataType="UInt">0</_x003C_From_x003E_k__BackingField>
                        <_x003C_To_x003E_k__BackingField dataType="UInt">1</_x003C_To_x003E_k__BackingField>
                        <prevent dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[FNaFMP.Office.MovePrevent]]" id="4116932036" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="3263803716">
                              <item dataType="Enum" type="FNaFMP.Core+Character" name="Bonnie" value="2" />
                              <item dataType="Enum" type="FNaFMP.Core+Character" name="Chica" value="3" />
                            </keys>
                            <values dataType="Array" type="System.Object[]" id="872739478">
                              <item dataType="Struct" type="FNaFMP.Office.MovePrevent" id="2496514254">
                                <_x003C_Position_x003E_k__BackingField dataType="Int">0</_x003C_Position_x003E_k__BackingField>
                                <equal dataType="Bool">true</equal>
                              </item>
                              <item dataType="Struct" type="FNaFMP.Office.MovePrevent" id="855838538">
                                <_x003C_Position_x003E_k__BackingField dataType="Int">0</_x003C_Position_x003E_k__BackingField>
                                <equal dataType="Bool">true</equal>
                              </item>
                            </values>
                          </body>
                        </prevent>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.Movement" id="2518532118">
                        <_x003C_From_x003E_k__BackingField dataType="UInt">0</_x003C_From_x003E_k__BackingField>
                        <_x003C_To_x003E_k__BackingField dataType="UInt">10</_x003C_To_x003E_k__BackingField>
                        <prevent dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[FNaFMP.Office.MovePrevent]]" id="2064391990" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="1201888096">
                              <item dataType="Enum" type="FNaFMP.Core+Character" name="Bonnie" value="2" />
                              <item dataType="Enum" type="FNaFMP.Core+Character" name="Chica" value="3" />
                            </keys>
                            <values dataType="Array" type="System.Object[]" id="1851328654">
                              <item dataType="Struct" type="FNaFMP.Office.MovePrevent" id="612522930">
                                <_x003C_Position_x003E_k__BackingField dataType="Int">0</_x003C_Position_x003E_k__BackingField>
                                <equal dataType="Bool">true</equal>
                              </item>
                              <item dataType="Struct" type="FNaFMP.Office.MovePrevent" id="3112555082">
                                <_x003C_Position_x003E_k__BackingField dataType="Int">0</_x003C_Position_x003E_k__BackingField>
                                <equal dataType="Bool">true</equal>
                              </item>
                            </values>
                          </body>
                        </prevent>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.Movement" id="3962720264">
                        <_x003C_From_x003E_k__BackingField dataType="UInt">1</_x003C_From_x003E_k__BackingField>
                        <_x003C_To_x003E_k__BackingField dataType="UInt">10</_x003C_To_x003E_k__BackingField>
                        <prevent dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[FNaFMP.Office.MovePrevent]]" id="3445339800" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="2683590188" length="0" />
                            <values dataType="Array" type="System.Object[]" id="1492120502" length="0" />
                          </body>
                        </prevent>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.Movement" id="1746699186">
                        <_x003C_From_x003E_k__BackingField dataType="UInt">1</_x003C_From_x003E_k__BackingField>
                        <_x003C_To_x003E_k__BackingField dataType="UInt">9</_x003C_To_x003E_k__BackingField>
                        <prevent dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[FNaFMP.Office.MovePrevent]]" id="2450894474" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="3328334816" length="0" />
                            <values dataType="Array" type="System.Object[]" id="1239952270" length="0" />
                          </body>
                        </prevent>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.Movement" id="607008820">
                        <_x003C_From_x003E_k__BackingField dataType="UInt">10</_x003C_From_x003E_k__BackingField>
                        <_x003C_To_x003E_k__BackingField dataType="UInt">1</_x003C_To_x003E_k__BackingField>
                        <prevent dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[FNaFMP.Office.MovePrevent]]" id="1770385884" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="794040004" length="0" />
                            <values dataType="Array" type="System.Object[]" id="3342853014" length="0" />
                          </body>
                        </prevent>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.Movement" id="1641844110">
                        <_x003C_From_x003E_k__BackingField dataType="UInt">10</_x003C_From_x003E_k__BackingField>
                        <_x003C_To_x003E_k__BackingField dataType="UInt">9</_x003C_To_x003E_k__BackingField>
                        <prevent dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[FNaFMP.Office.MovePrevent]]" id="3312948750" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="1100300240" length="0" />
                            <values dataType="Array" type="System.Object[]" id="1303380590" length="0" />
                          </body>
                        </prevent>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.Movement" id="2926641088">
                        <_x003C_From_x003E_k__BackingField dataType="UInt">9</_x003C_From_x003E_k__BackingField>
                        <_x003C_To_x003E_k__BackingField dataType="UInt">10</_x003C_To_x003E_k__BackingField>
                        <prevent dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[FNaFMP.Office.MovePrevent]]" id="3964154640" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="1632997180" length="0" />
                            <values dataType="Array" type="System.Object[]" id="2281462678" length="0" />
                          </body>
                        </prevent>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.Movement" id="2898020106">
                        <_x003C_From_x003E_k__BackingField dataType="UInt">9</_x003C_From_x003E_k__BackingField>
                        <_x003C_To_x003E_k__BackingField dataType="UInt">1</_x003C_To_x003E_k__BackingField>
                        <prevent dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[FNaFMP.Office.MovePrevent]]" id="1466148098" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="3531778448" length="0" />
                            <values dataType="Array" type="System.Object[]" id="3243610862" length="0" />
                          </body>
                        </prevent>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.Movement" id="1608129932">
                        <_x003C_From_x003E_k__BackingField dataType="UInt">9</_x003C_From_x003E_k__BackingField>
                        <_x003C_To_x003E_k__BackingField dataType="UInt">6</_x003C_To_x003E_k__BackingField>
                        <prevent dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[FNaFMP.Office.MovePrevent]]" id="2462367188" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="437724388" length="0" />
                            <values dataType="Array" type="System.Object[]" id="4160552470" length="0" />
                          </body>
                        </prevent>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.Movement" id="3070251750">
                        <_x003C_From_x003E_k__BackingField dataType="UInt">6</_x003C_From_x003E_k__BackingField>
                        <_x003C_To_x003E_k__BackingField dataType="UInt">9</_x003C_To_x003E_k__BackingField>
                        <prevent dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[FNaFMP.Office.MovePrevent]]" id="3297070822" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="2712810880" length="0" />
                            <values dataType="Array" type="System.Object[]" id="1047435470" length="0" />
                          </body>
                        </prevent>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.Movement" id="275296504">
                        <_x003C_From_x003E_k__BackingField dataType="UInt">6</_x003C_From_x003E_k__BackingField>
                        <_x003C_To_x003E_k__BackingField dataType="UInt">7</_x003C_To_x003E_k__BackingField>
                        <prevent dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[FNaFMP.Office.MovePrevent]]" id="3311756712" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="3370804908" length="0" />
                            <values dataType="Array" type="System.Object[]" id="1278824886" length="0" />
                          </body>
                        </prevent>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.Movement" id="712917250">
                        <_x003C_From_x003E_k__BackingField dataType="UInt">7</_x003C_From_x003E_k__BackingField>
                        <_x003C_To_x003E_k__BackingField dataType="UInt">6</_x003C_To_x003E_k__BackingField>
                        <prevent dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[FNaFMP.Office.MovePrevent]]" id="80281530" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="2736769024" length="0" />
                            <values dataType="Array" type="System.Object[]" id="3887639502" length="0" />
                          </body>
                        </prevent>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.Movement" id="2806206500">
                        <_x003C_From_x003E_k__BackingField dataType="UInt">7</_x003C_From_x003E_k__BackingField>
                        <_x003C_To_x003E_k__BackingField dataType="UInt">21</_x003C_To_x003E_k__BackingField>
                        <prevent dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[FNaFMP.Office.MovePrevent]]" id="2775607788" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="4279278180">
                              <item dataType="Enum" type="FNaFMP.Core+Character" name="Bonnie" value="2" />
                              <item dataType="Enum" type="FNaFMP.Core+Character" name="Chica" value="3" />
                              <item dataType="Enum" type="FNaFMP.Core+Character" name="Foxy" value="4" />
                            </keys>
                            <values dataType="Array" type="System.Object[]" id="2076166166">
                              <item dataType="Struct" type="FNaFMP.Office.MovePrevent" id="1830731054">
                                <_x003C_Position_x003E_k__BackingField dataType="Int">22</_x003C_Position_x003E_k__BackingField>
                                <equal dataType="Bool">true</equal>
                              </item>
                              <item dataType="Struct" type="FNaFMP.Office.MovePrevent" id="2372915402">
                                <_x003C_Position_x003E_k__BackingField dataType="Int">22</_x003C_Position_x003E_k__BackingField>
                                <equal dataType="Bool">true</equal>
                              </item>
                              <item dataType="Struct" type="FNaFMP.Office.MovePrevent" id="794359966">
                                <_x003C_Position_x003E_k__BackingField dataType="Int">5</_x003C_Position_x003E_k__BackingField>
                                <equal dataType="Bool">false</equal>
                              </item>
                            </values>
                          </body>
                        </prevent>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.Movement" id="1757002846">
                        <_x003C_From_x003E_k__BackingField dataType="UInt">1</_x003C_From_x003E_k__BackingField>
                        <_x003C_To_x003E_k__BackingField dataType="UInt">0</_x003C_To_x003E_k__BackingField>
                        <prevent dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[FNaFMP.Office.MovePrevent]]" id="2631296190" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="3951672336" length="0" />
                            <values dataType="Array" type="System.Object[]" id="787631342" length="0" />
                          </body>
                        </prevent>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.Movement" id="2783058608">
                        <_x003C_From_x003E_k__BackingField dataType="UInt">1</_x003C_From_x003E_k__BackingField>
                        <_x003C_To_x003E_k__BackingField dataType="UInt">6</_x003C_To_x003E_k__BackingField>
                        <prevent dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[FNaFMP.Office.MovePrevent]]" id="1242605472" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="702438108" length="0" />
                            <values dataType="Array" type="System.Object[]" id="938315030" length="0" />
                          </body>
                        </prevent>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.Movement" id="2376110170">
                        <_x003C_From_x003E_k__BackingField dataType="UInt">6</_x003C_From_x003E_k__BackingField>
                        <_x003C_To_x003E_k__BackingField dataType="UInt">1</_x003C_To_x003E_k__BackingField>
                        <prevent dataType="Struct" type="System.Collections.Generic.Dictionary`2[[FNaFMP.Core+Character],[FNaFMP.Office.MovePrevent]]" id="84199730" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="1876544464" length="0" />
                            <values dataType="Array" type="System.Object[]" id="563737198" length="0" />
                          </body>
                        </prevent>
                      </item>
                    </_items>
                    <_size dataType="Int">16</_size>
                  </item>
                </values>
              </body>
            </movements>
          </item>
          <item dataType="Struct" type="FNaFMP.Office.OfficeLightRenderer" id="2953169281">
            <active dataType="Bool">true</active>
            <animator />
            <def dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Office\office_def.Material.res</contentPath>
            </def>
            <gameobj dataType="ObjectRef">194760272</gameobj>
            <left dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Office.CameraView]]" id="3035533341">
              <_items dataType="Array" type="FNaFMP.Office.CameraView[]" id="337823974" length="4">
                <item dataType="Struct" type="FNaFMP.Office.CameraView" id="3652064640">
                  <duration dataType="Float">0</duration>
                  <extra dataType="Int">-1</extra>
                  <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                    <contentPath dataType="String">Data\Office\office_Lnone.Material.res</contentPath>
                  </mat>
                  <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="FixedSingle" value="4" />
                  <move dataType="Bool">true</move>
                  <robots />
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </left>
            <renderer />
            <right dataType="Struct" type="System.Collections.Generic.List`1[[FNaFMP.Office.CameraView]]" id="2133841656">
              <_items dataType="Array" type="FNaFMP.Office.CameraView[]" id="1164822391" length="4">
                <item dataType="Struct" type="FNaFMP.Office.CameraView" id="4234420110">
                  <duration dataType="Float">0</duration>
                  <extra dataType="Int">-1</extra>
                  <mat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                    <contentPath dataType="String">Data\Office\office_Rnone.Material.res</contentPath>
                  </mat>
                  <mode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="FixedSingle" value="4" />
                  <move dataType="Bool">true</move>
                  <robots />
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </right>
            <startup dataType="Bool">false</startup>
            <transform />
          </item>
        </_items>
        <_size dataType="Int">7</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1548074518" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="47991744">
            <item dataType="ObjectRef">3757206646</item>
            <item dataType="Type" id="1240285980" value="Duality.Components.Renderers.SpriteRenderer" />
            <item dataType="Type" id="1128967702" value="Duality.Components.Renderers.SpriteAnimator" />
            <item dataType="Type" id="542711944" value="FNaFMP.Office.OfficeLightRenderer" />
            <item dataType="Type" id="1708985266" value="FNaFMP.Office.CameraRenderer" />
            <item dataType="Type" id="4073972148" value="FNaFMP.Office.FreddyPoster" />
            <item dataType="Type" id="3293687950" value="FNaFMP.Office.MovementControl" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2117106766">
            <item dataType="ObjectRef">252037490</item>
            <item dataType="ObjectRef">1663379552</item>
            <item dataType="ObjectRef">4229924108</item>
            <item dataType="ObjectRef">2953169281</item>
            <item dataType="ObjectRef">3780257928</item>
            <item dataType="ObjectRef">3461982009</item>
            <item dataType="ObjectRef">1895485408</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">252037490</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1234386780">HcRCMSH0mE6QBX6RzUYOSA==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">office</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="1623135267">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2381479441">
        <_items dataType="Array" type="Duality.Component[]" id="2608577774" length="8">
          <item dataType="Struct" type="Duality.Components.Transform" id="1680412485">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">1623135267</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3091754547">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">0</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">1623135267</gameobj>
            <offset dataType="Float">150</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">720</H>
              <W dataType="Float">1280</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\static\static_loop.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">2</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="1363331807">
            <active dataType="Bool">true</active>
            <animDuration dataType="Float">0.3</animDuration>
            <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
            <animTime dataType="Float">0.08524992</animTime>
            <customFrameSequence />
            <firstFrame dataType="Int">0</firstFrame>
            <frameCount dataType="Int">8</frameCount>
            <gameobj dataType="ObjectRef">1623135267</gameobj>
            <paused dataType="Bool">false</paused>
          </item>
          <item dataType="Struct" type="FNaFMP.Office.Static" id="1102931415">
            <active dataType="Bool">true</active>
            <dark dataType="Int">0</dark>
            <gameobj dataType="ObjectRef">1623135267</gameobj>
            <lastTime dataType="Int">0</lastTime>
            <rnd dataType="Struct" type="System.Random" id="3324508583">
              <inext dataType="Int">0</inext>
              <inextp dataType="Int">21</inextp>
              <SeedArray dataType="Array" type="System.Int32[]" id="3921513422">0, 90793558, 953079675, 1199634286, 1603037885, 513619741, 485524611, 204975276, 1932277061, 1433855577, 877077343, 1739985958, 382418377, 2001437569, 596503276, 13753412, 14135104, 1036829049, 1794143826, 360118856, 1718949841, 701802116, 601299138, 1466566892, 691722001, 30189946, 612323199, 61358857, 927698208, 656729141, 31023558, 360788697, 1720682233, 1799821520, 982093778, 1756989437, 1132578150, 1845787846, 1863356329, 1708334406, 1129934582, 847882197, 961041244, 376507634, 236192859, 219542485, 1468836720, 994109302, 674504481, 9776401, 781316774, 1314432063, 887599120, 1633785636, 1137373604, 722292405</SeedArray>
            </rnd>
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1855582624" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3482479547">
            <item dataType="ObjectRef">3757206646</item>
            <item dataType="ObjectRef">1240285980</item>
            <item dataType="ObjectRef">1128967702</item>
            <item dataType="Type" id="2620617942" value="FNaFMP.Office.Static" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="3106142248">
            <item dataType="ObjectRef">1680412485</item>
            <item dataType="ObjectRef">3091754547</item>
            <item dataType="ObjectRef">1363331807</item>
            <item dataType="ObjectRef">1102931415</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1680412485</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="714479153">utyjjlKBuUuwhtE3Vm68Qw==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Static</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2142513618">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="471103036">
        <_items dataType="Array" type="Duality.Component[]" id="11098436" length="8">
          <item dataType="Struct" type="Duality.Components.Transform" id="2199790836">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2142513618</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">848.6271</X>
              <Y dataType="Float">400.934937</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">848.6271</X>
              <Y dataType="Float">400.934937</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3611132898">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">2142513618</gameobj>
            <offset dataType="Float">150</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">196</H>
              <W dataType="Float">137</W>
              <X dataType="Float">-68.5</X>
              <Y dataType="Float">-98</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\fan\fan_loop.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">0</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
          <item dataType="Struct" type="Duality.Components.VelocityTracker" id="4213648085">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2142513618</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="1882710158">
            <active dataType="Bool">true</active>
            <animDuration dataType="Float">0.1</animDuration>
            <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
            <animTime dataType="Float">0</animTime>
            <customFrameSequence />
            <firstFrame dataType="Int">0</firstFrame>
            <frameCount dataType="Int">3</frameCount>
            <gameobj dataType="ObjectRef">2142513618</gameobj>
            <paused dataType="Bool">false</paused>
          </item>
          <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="1738189146">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2142513618</gameobj>
            <render />
          </item>
        </_items>
        <_size dataType="Int">5</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3692327318" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="214713878">
            <item dataType="ObjectRef">3757206646</item>
            <item dataType="ObjectRef">1240285980</item>
            <item dataType="ObjectRef">1128967702</item>
            <item dataType="ObjectRef">264927126</item>
            <item dataType="Type" id="1180528928" value="FNaFMP.Office.VisibilityController" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="4221866970">
            <item dataType="ObjectRef">2199790836</item>
            <item dataType="ObjectRef">3611132898</item>
            <item dataType="ObjectRef">1882710158</item>
            <item dataType="ObjectRef">4213648085</item>
            <item dataType="ObjectRef">1738189146</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2199790836</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="2069137846">vsijhVxHLUuqA546/IN3Mg==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">fan_loop</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="116715865">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="4204727803">
        <_items dataType="Array" type="Duality.Component[]" id="3071867478" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="173993083">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">116715865</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="1585335145">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">0</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">116715865</gameobj>
            <offset dataType="Float">100</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">720</H>
              <W dataType="Float">1280</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Camera\frame.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">-1</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
          </item>
          <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="4007358689">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">116715865</gameobj>
            <render />
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3736930216" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2765595153">
            <item dataType="ObjectRef">3757206646</item>
            <item dataType="ObjectRef">1240285980</item>
            <item dataType="ObjectRef">1180528928</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="1101713824">
            <item dataType="ObjectRef">173993083</item>
            <item dataType="ObjectRef">1585335145</item>
            <item dataType="ObjectRef">4007358689</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">173993083</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="2839037827">/d74TxHo/kKNm9prAqIJPA==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">frame</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="1076695493">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3861657783">
        <_items dataType="Array" type="Duality.Component[]" id="1175708558">
          <item dataType="Struct" type="Duality.Components.Transform" id="1133972711">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">1076695493</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2545314773">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">0</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">1076695493</gameobj>
            <offset dataType="Float">100</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">50</H>
              <W dataType="Float">50</W>
              <X dataType="Float">25</X>
              <Y dataType="Float">25</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Camera\recording_anim.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">0</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="816892033">
            <active dataType="Bool">true</active>
            <animDuration dataType="Float">2</animDuration>
            <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
            <animTime dataType="Float">0</animTime>
            <customFrameSequence />
            <firstFrame dataType="Int">0</firstFrame>
            <frameCount dataType="Int">2</frameCount>
            <gameobj dataType="ObjectRef">1076695493</gameobj>
            <paused dataType="Bool">false</paused>
          </item>
          <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="672371021">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1076695493</gameobj>
            <render />
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3233747776" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2129247997">
            <item dataType="ObjectRef">3757206646</item>
            <item dataType="ObjectRef">1240285980</item>
            <item dataType="ObjectRef">1128967702</item>
            <item dataType="ObjectRef">1180528928</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="2738089912">
            <item dataType="ObjectRef">1133972711</item>
            <item dataType="ObjectRef">2545314773</item>
            <item dataType="ObjectRef">816892033</item>
            <item dataType="ObjectRef">672371021</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1133972711</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="2768573911">G3gm1D9fbUOiCAgVu7g7kQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">recording_anim</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="436961546">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2995973460">
        <_items dataType="Array" type="Duality.Component[]" id="3459905252">
          <item dataType="Struct" type="Duality.Components.Transform" id="494238764">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">436961546</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.VelocityTracker" id="2508096013">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">436961546</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.SoundEmitter" id="2657773429">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">436961546</gameobj>
            <sources dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.SoundEmitter+Source]]" id="1474143449">
              <_items dataType="Array" type="Duality.Components.SoundEmitter+Source[]" id="4039163342" length="4">
                <item dataType="Struct" type="Duality.Components.SoundEmitter+Source" id="2735004112">
                  <looped dataType="Bool">true</looped>
                  <lowpass dataType="Float">1</lowpass>
                  <offset dataType="Struct" type="Duality.Vector3" />
                  <paused dataType="Bool">true</paused>
                  <pitch dataType="Float">1</pitch>
                  <sound dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
                    <contentPath dataType="String">Data\fan\fan_sound.Sound.res</contentPath>
                  </sound>
                  <volume dataType="Float">1</volume>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </sources>
          </item>
          <item dataType="Struct" type="FNaFMP.Utility.SoundManager" id="1934141442">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">436961546</gameobj>
            <transform />
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3995492790" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2193778430">
            <item dataType="ObjectRef">3757206646</item>
            <item dataType="ObjectRef">264927126</item>
            <item dataType="Type" id="3795356048" value="Duality.Components.SoundEmitter" />
            <item dataType="Type" id="3273609966" value="FNaFMP.Utility.SoundManager" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2805917578">
            <item dataType="ObjectRef">494238764</item>
            <item dataType="ObjectRef">2508096013</item>
            <item dataType="ObjectRef">2657773429</item>
            <item dataType="ObjectRef">1934141442</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">494238764</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="10724494">ivjsTipGR0Ok+K7WaYjuDQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Sound</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="3555090940">
      <active dataType="Bool">true</active>
      <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="1130836882">
        <_items dataType="Array" type="Duality.GameObject[]" id="2844495440" length="4">
          <item dataType="Struct" type="Duality.GameObject" id="2578211885">
            <active dataType="Bool">true</active>
            <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="209214969">
              <_items dataType="Array" type="Duality.GameObject[]" id="4241630798" length="16">
                <item dataType="Struct" type="Duality.GameObject" id="4075703128">
                  <active dataType="Bool">true</active>
                  <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="2003491204">
                    <_items dataType="Array" type="Duality.GameObject[]" id="693106756" length="4">
                      <item dataType="Struct" type="Duality.GameObject" id="2586317313">
                        <active dataType="Bool">true</active>
                        <children />
                        <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3883860893">
                          <_items dataType="Array" type="Duality.Component[]" id="2882349798" length="4">
                            <item dataType="Struct" type="Duality.Components.Transform" id="2643594531">
                              <active dataType="Bool">true</active>
                              <angle dataType="Float">0</angle>
                              <angleAbs dataType="Float">0</angleAbs>
                              <gameobj dataType="ObjectRef">2586317313</gameobj>
                              <ignoreParent dataType="Bool">false</ignoreParent>
                              <pos dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">7</X>
                                <Y dataType="Float">7</Y>
                                <Z dataType="Float">0</Z>
                              </pos>
                              <posAbs dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">959</X>
                                <Y dataType="Float">332</Y>
                                <Z dataType="Float">0</Z>
                              </posAbs>
                              <scale dataType="Float">1</scale>
                              <scaleAbs dataType="Float">1</scaleAbs>
                            </item>
                            <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="4054936593">
                              <active dataType="Bool">true</active>
                              <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                                <A dataType="Byte">0</A>
                                <B dataType="Byte">255</B>
                                <G dataType="Byte">255</G>
                                <R dataType="Byte">255</R>
                              </colorTint>
                              <customMat />
                              <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                              <gameobj dataType="ObjectRef">2586317313</gameobj>
                              <offset dataType="Float">0</offset>
                              <pixelGrid dataType="Bool">false</pixelGrid>
                              <rect dataType="Struct" type="Duality.Rect">
                                <H dataType="Float">25</H>
                                <W dataType="Float">31</W>
                                <X dataType="Float">0</X>
                                <Y dataType="Float">0</Y>
                              </rect>
                              <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                              <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                                <contentPath dataType="String">Data\Camera\button\Text\1a.Material.res</contentPath>
                              </sharedMat>
                              <spriteIndex dataType="Int">-1</spriteIndex>
                              <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                            </item>
                            <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="2181992841">
                              <active dataType="Bool">true</active>
                              <gameobj dataType="ObjectRef">2586317313</gameobj>
                              <render />
                            </item>
                          </_items>
                          <_size dataType="Int">3</_size>
                        </compList>
                        <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1098743032" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="658668791">
                              <item dataType="ObjectRef">3757206646</item>
                              <item dataType="ObjectRef">1240285980</item>
                              <item dataType="ObjectRef">1180528928</item>
                            </keys>
                            <values dataType="Array" type="System.Object[]" id="2341431872">
                              <item dataType="ObjectRef">2643594531</item>
                              <item dataType="ObjectRef">4054936593</item>
                              <item dataType="ObjectRef">2181992841</item>
                            </values>
                          </body>
                        </compMap>
                        <compTransform dataType="ObjectRef">2643594531</compTransform>
                        <identifier dataType="Struct" type="System.Guid" surrogate="true">
                          <header>
                            <data dataType="Array" type="System.Byte[]" id="2338431317">boJcwF+To0Oqhk6Tj21tYw==</data>
                          </header>
                          <body />
                        </identifier>
                        <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                        <name dataType="String">text</name>
                        <parent dataType="ObjectRef">4075703128</parent>
                        <prefabLink />
                      </item>
                    </_items>
                    <_size dataType="Int">1</_size>
                  </children>
                  <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2574650518">
                    <_items dataType="Array" type="Duality.Component[]" id="3241027470" length="8">
                      <item dataType="Struct" type="Duality.Components.Transform" id="4132980346">
                        <active dataType="Bool">true</active>
                        <angle dataType="Float">0</angle>
                        <angleAbs dataType="Float">0</angleAbs>
                        <gameobj dataType="ObjectRef">4075703128</gameobj>
                        <ignoreParent dataType="Bool">false</ignoreParent>
                        <pos dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">952</X>
                          <Y dataType="Float">325</Y>
                          <Z dataType="Float">0</Z>
                        </pos>
                        <posAbs dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">952</X>
                          <Y dataType="Float">325</Y>
                          <Z dataType="Float">0</Z>
                        </posAbs>
                        <scale dataType="Float">1</scale>
                        <scaleAbs dataType="Float">1</scaleAbs>
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="1249355112">
                        <active dataType="Bool">true</active>
                        <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                          <A dataType="Byte">0</A>
                          <B dataType="Byte">255</B>
                          <G dataType="Byte">255</G>
                          <R dataType="Byte">255</R>
                        </colorTint>
                        <customMat />
                        <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                        <gameobj dataType="ObjectRef">4075703128</gameobj>
                        <offset dataType="Float">79</offset>
                        <pixelGrid dataType="Bool">false</pixelGrid>
                        <rect dataType="Struct" type="Duality.Rect">
                          <H dataType="Float">40</H>
                          <W dataType="Float">60</W>
                          <X dataType="Float">0</X>
                          <Y dataType="Float">0</Y>
                        </rect>
                        <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                        <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                          <contentPath dataType="String">Data\Camera\button\button.Material.res</contentPath>
                        </sharedMat>
                        <spriteIndex dataType="Int">0</spriteIndex>
                        <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="3815899668">
                        <active dataType="Bool">true</active>
                        <animDuration dataType="Float">2</animDuration>
                        <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
                        <animTime dataType="Float">0</animTime>
                        <customFrameSequence />
                        <firstFrame dataType="Int">0</firstFrame>
                        <frameCount dataType="Int">2</frameCount>
                        <gameobj dataType="ObjectRef">4075703128</gameobj>
                        <paused dataType="Bool">false</paused>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.CameraButton" id="2585921855">
                        <active dataType="Bool">true</active>
                        <animator />
                        <gameobj dataType="ObjectRef">4075703128</gameobj>
                        <number dataType="Int">0</number>
                        <renderer />
                        <transform />
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="3671378656">
                        <active dataType="Bool">true</active>
                        <gameobj dataType="ObjectRef">4075703128</gameobj>
                        <render />
                      </item>
                    </_items>
                    <_size dataType="Int">5</_size>
                  </compList>
                  <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3191916352" surrogate="true">
                    <header />
                    <body>
                      <keys dataType="Array" type="System.Object[]" id="2461350600">
                        <item dataType="ObjectRef">3757206646</item>
                        <item dataType="ObjectRef">1240285980</item>
                        <item dataType="ObjectRef">1128967702</item>
                        <item dataType="ObjectRef">1180528928</item>
                        <item dataType="Type" id="2905165420" value="FNaFMP.Office.CameraButton" />
                      </keys>
                      <values dataType="Array" type="System.Object[]" id="4045162206">
                        <item dataType="ObjectRef">4132980346</item>
                        <item dataType="ObjectRef">1249355112</item>
                        <item dataType="ObjectRef">3815899668</item>
                        <item dataType="ObjectRef">3671378656</item>
                        <item dataType="ObjectRef">2585921855</item>
                      </values>
                    </body>
                  </compMap>
                  <compTransform dataType="ObjectRef">4132980346</compTransform>
                  <identifier dataType="Struct" type="System.Guid" surrogate="true">
                    <header>
                      <data dataType="Array" type="System.Byte[]" id="2762364724">TN+1jnkaGECqQZiFmUZO/g==</data>
                    </header>
                    <body />
                  </identifier>
                  <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                  <name dataType="String">Cam 1A</name>
                  <parent dataType="ObjectRef">2578211885</parent>
                  <prefabLink />
                </item>
                <item dataType="Struct" type="Duality.GameObject" id="2628574494">
                  <active dataType="Bool">true</active>
                  <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="1178078962">
                    <_items dataType="Array" type="Duality.GameObject[]" id="158258640" length="4">
                      <item dataType="Struct" type="Duality.GameObject" id="525618244">
                        <active dataType="Bool">true</active>
                        <children />
                        <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="650111276">
                          <_items dataType="Array" type="Duality.Component[]" id="864444132" length="4">
                            <item dataType="Struct" type="Duality.Components.Transform" id="582895462">
                              <active dataType="Bool">true</active>
                              <angle dataType="Float">0</angle>
                              <angleAbs dataType="Float">0</angleAbs>
                              <gameobj dataType="ObjectRef">525618244</gameobj>
                              <ignoreParent dataType="Bool">false</ignoreParent>
                              <pos dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">7</X>
                                <Y dataType="Float">7</Y>
                                <Z dataType="Float">0</Z>
                              </pos>
                              <posAbs dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">941</X>
                                <Y dataType="Float">382</Y>
                                <Z dataType="Float">0</Z>
                              </posAbs>
                              <scale dataType="Float">1</scale>
                              <scaleAbs dataType="Float">1</scaleAbs>
                            </item>
                            <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="1994237524">
                              <active dataType="Bool">true</active>
                              <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                                <A dataType="Byte">0</A>
                                <B dataType="Byte">255</B>
                                <G dataType="Byte">255</G>
                                <R dataType="Byte">255</R>
                              </colorTint>
                              <customMat />
                              <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                              <gameobj dataType="ObjectRef">525618244</gameobj>
                              <offset dataType="Float">0</offset>
                              <pixelGrid dataType="Bool">false</pixelGrid>
                              <rect dataType="Struct" type="Duality.Rect">
                                <H dataType="Float">25</H>
                                <W dataType="Float">31</W>
                                <X dataType="Float">0</X>
                                <Y dataType="Float">0</Y>
                              </rect>
                              <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                              <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                                <contentPath dataType="String">Data\Camera\button\Text\1b.Material.res</contentPath>
                              </sharedMat>
                              <spriteIndex dataType="Int">-1</spriteIndex>
                              <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                            </item>
                            <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="121293772">
                              <active dataType="Bool">true</active>
                              <gameobj dataType="ObjectRef">525618244</gameobj>
                              <render />
                            </item>
                          </_items>
                          <_size dataType="Int">3</_size>
                        </compList>
                        <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3980093878" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="3958078310">
                              <item dataType="ObjectRef">3757206646</item>
                              <item dataType="ObjectRef">1240285980</item>
                              <item dataType="ObjectRef">1180528928</item>
                            </keys>
                            <values dataType="Array" type="System.Object[]" id="4058658618">
                              <item dataType="ObjectRef">582895462</item>
                              <item dataType="ObjectRef">1994237524</item>
                              <item dataType="ObjectRef">121293772</item>
                            </values>
                          </body>
                        </compMap>
                        <compTransform dataType="ObjectRef">582895462</compTransform>
                        <identifier dataType="Struct" type="System.Guid" surrogate="true">
                          <header>
                            <data dataType="Array" type="System.Byte[]" id="1964139494">MiGGGbQTRkyYv55+XmciHw==</data>
                          </header>
                          <body />
                        </identifier>
                        <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                        <name dataType="String">text</name>
                        <parent dataType="ObjectRef">2628574494</parent>
                        <prefabLink />
                      </item>
                    </_items>
                    <_size dataType="Int">1</_size>
                  </children>
                  <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2250103114">
                    <_items dataType="Array" type="Duality.Component[]" id="2667157736" length="8">
                      <item dataType="Struct" type="Duality.Components.Transform" id="2685851712">
                        <active dataType="Bool">true</active>
                        <angle dataType="Float">0</angle>
                        <angleAbs dataType="Float">0</angleAbs>
                        <gameobj dataType="ObjectRef">2628574494</gameobj>
                        <ignoreParent dataType="Bool">false</ignoreParent>
                        <pos dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">934</X>
                          <Y dataType="Float">375</Y>
                          <Z dataType="Float">0</Z>
                        </pos>
                        <posAbs dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">934</X>
                          <Y dataType="Float">375</Y>
                          <Z dataType="Float">0</Z>
                        </posAbs>
                        <scale dataType="Float">1</scale>
                        <scaleAbs dataType="Float">1</scaleAbs>
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="4097193774">
                        <active dataType="Bool">true</active>
                        <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                          <A dataType="Byte">0</A>
                          <B dataType="Byte">255</B>
                          <G dataType="Byte">255</G>
                          <R dataType="Byte">255</R>
                        </colorTint>
                        <customMat />
                        <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                        <gameobj dataType="ObjectRef">2628574494</gameobj>
                        <offset dataType="Float">79</offset>
                        <pixelGrid dataType="Bool">false</pixelGrid>
                        <rect dataType="Struct" type="Duality.Rect">
                          <H dataType="Float">40</H>
                          <W dataType="Float">60</W>
                          <X dataType="Float">0</X>
                          <Y dataType="Float">0</Y>
                        </rect>
                        <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                        <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                          <contentPath dataType="String">Data\Camera\button\button.Material.res</contentPath>
                        </sharedMat>
                        <spriteIndex dataType="Int">0</spriteIndex>
                        <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="2368771034">
                        <active dataType="Bool">true</active>
                        <animDuration dataType="Float">2</animDuration>
                        <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
                        <animTime dataType="Float">0</animTime>
                        <customFrameSequence />
                        <firstFrame dataType="Int">0</firstFrame>
                        <frameCount dataType="Int">2</frameCount>
                        <gameobj dataType="ObjectRef">2628574494</gameobj>
                        <paused dataType="Bool">false</paused>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.CameraButton" id="1138793221">
                        <active dataType="Bool">true</active>
                        <animator />
                        <gameobj dataType="ObjectRef">2628574494</gameobj>
                        <number dataType="Int">1</number>
                        <renderer />
                        <transform />
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="2224250022">
                        <active dataType="Bool">true</active>
                        <gameobj dataType="ObjectRef">2628574494</gameobj>
                        <render />
                      </item>
                    </_items>
                    <_size dataType="Int">5</_size>
                  </compList>
                  <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3299236290" surrogate="true">
                    <header />
                    <body>
                      <keys dataType="Array" type="System.Object[]" id="277282080">
                        <item dataType="ObjectRef">3757206646</item>
                        <item dataType="ObjectRef">1240285980</item>
                        <item dataType="ObjectRef">1128967702</item>
                        <item dataType="ObjectRef">1180528928</item>
                        <item dataType="ObjectRef">2905165420</item>
                      </keys>
                      <values dataType="Array" type="System.Object[]" id="2684395406">
                        <item dataType="ObjectRef">2685851712</item>
                        <item dataType="ObjectRef">4097193774</item>
                        <item dataType="ObjectRef">2368771034</item>
                        <item dataType="ObjectRef">2224250022</item>
                        <item dataType="ObjectRef">1138793221</item>
                      </values>
                    </body>
                  </compMap>
                  <compTransform dataType="ObjectRef">2685851712</compTransform>
                  <identifier dataType="Struct" type="System.Guid" surrogate="true">
                    <header>
                      <data dataType="Array" type="System.Byte[]" id="376443964">3ku04UXu8EeNveVXKVNudg==</data>
                    </header>
                    <body />
                  </identifier>
                  <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                  <name dataType="String">Cam 1B</name>
                  <parent dataType="ObjectRef">2578211885</parent>
                  <prefabLink />
                </item>
                <item dataType="Struct" type="Duality.GameObject" id="3270008394">
                  <active dataType="Bool">true</active>
                  <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="103278542">
                    <_items dataType="Array" type="Duality.GameObject[]" id="3010621904" length="4">
                      <item dataType="Struct" type="Duality.GameObject" id="1706951847">
                        <active dataType="Bool">true</active>
                        <children />
                        <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1552236035">
                          <_items dataType="Array" type="Duality.Component[]" id="2224859430" length="4">
                            <item dataType="Struct" type="Duality.Components.Transform" id="1764229065">
                              <active dataType="Bool">true</active>
                              <angle dataType="Float">0</angle>
                              <angleAbs dataType="Float">0</angleAbs>
                              <gameobj dataType="ObjectRef">1706951847</gameobj>
                              <ignoreParent dataType="Bool">false</ignoreParent>
                              <pos dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">7</X>
                                <Y dataType="Float">7</Y>
                                <Z dataType="Float">0</Z>
                              </pos>
                              <posAbs dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">1166</X>
                                <Y dataType="Float">544</Y>
                                <Z dataType="Float">0</Z>
                              </posAbs>
                              <scale dataType="Float">1</scale>
                              <scaleAbs dataType="Float">1</scaleAbs>
                            </item>
                            <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3175571127">
                              <active dataType="Bool">true</active>
                              <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                                <A dataType="Byte">0</A>
                                <B dataType="Byte">255</B>
                                <G dataType="Byte">255</G>
                                <R dataType="Byte">255</R>
                              </colorTint>
                              <customMat />
                              <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                              <gameobj dataType="ObjectRef">1706951847</gameobj>
                              <offset dataType="Float">0</offset>
                              <pixelGrid dataType="Bool">false</pixelGrid>
                              <rect dataType="Struct" type="Duality.Rect">
                                <H dataType="Float">25</H>
                                <W dataType="Float">31</W>
                                <X dataType="Float">0</X>
                                <Y dataType="Float">0</Y>
                              </rect>
                              <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                              <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                                <contentPath dataType="String">Data\Camera\button\Text\6.Material.res</contentPath>
                              </sharedMat>
                              <spriteIndex dataType="Int">-1</spriteIndex>
                              <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                            </item>
                            <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="1302627375">
                              <active dataType="Bool">true</active>
                              <gameobj dataType="ObjectRef">1706951847</gameobj>
                              <render />
                            </item>
                          </_items>
                          <_size dataType="Int">3</_size>
                        </compList>
                        <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3746295736" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="2160339305">
                              <item dataType="ObjectRef">3757206646</item>
                              <item dataType="ObjectRef">1240285980</item>
                              <item dataType="ObjectRef">1180528928</item>
                            </keys>
                            <values dataType="Array" type="System.Object[]" id="1690671808">
                              <item dataType="ObjectRef">1764229065</item>
                              <item dataType="ObjectRef">3175571127</item>
                              <item dataType="ObjectRef">1302627375</item>
                            </values>
                          </body>
                        </compMap>
                        <compTransform dataType="ObjectRef">1764229065</compTransform>
                        <identifier dataType="Struct" type="System.Guid" surrogate="true">
                          <header>
                            <data dataType="Array" type="System.Byte[]" id="1595736523">sl6xp+Z/3UqijCCegAmiVA==</data>
                          </header>
                          <body />
                        </identifier>
                        <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                        <name dataType="String">text</name>
                        <parent dataType="ObjectRef">3270008394</parent>
                        <prefabLink />
                      </item>
                    </_items>
                    <_size dataType="Int">1</_size>
                  </children>
                  <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1895646538">
                    <_items dataType="Array" type="Duality.Component[]" id="1665800844" length="8">
                      <item dataType="Struct" type="Duality.Components.Transform" id="3327285612">
                        <active dataType="Bool">true</active>
                        <angle dataType="Float">0</angle>
                        <angleAbs dataType="Float">0</angleAbs>
                        <gameobj dataType="ObjectRef">3270008394</gameobj>
                        <ignoreParent dataType="Bool">false</ignoreParent>
                        <pos dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">1159</X>
                          <Y dataType="Float">537</Y>
                          <Z dataType="Float">0</Z>
                        </pos>
                        <posAbs dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">1159</X>
                          <Y dataType="Float">537</Y>
                          <Z dataType="Float">0</Z>
                        </posAbs>
                        <scale dataType="Float">1</scale>
                        <scaleAbs dataType="Float">1</scaleAbs>
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="443660378">
                        <active dataType="Bool">true</active>
                        <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                          <A dataType="Byte">0</A>
                          <B dataType="Byte">255</B>
                          <G dataType="Byte">255</G>
                          <R dataType="Byte">255</R>
                        </colorTint>
                        <customMat />
                        <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                        <gameobj dataType="ObjectRef">3270008394</gameobj>
                        <offset dataType="Float">79</offset>
                        <pixelGrid dataType="Bool">false</pixelGrid>
                        <rect dataType="Struct" type="Duality.Rect">
                          <H dataType="Float">40</H>
                          <W dataType="Float">60</W>
                          <X dataType="Float">0</X>
                          <Y dataType="Float">0</Y>
                        </rect>
                        <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                        <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                          <contentPath dataType="String">Data\Camera\button\button.Material.res</contentPath>
                        </sharedMat>
                        <spriteIndex dataType="Int">0</spriteIndex>
                        <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="3010204934">
                        <active dataType="Bool">true</active>
                        <animDuration dataType="Float">2</animDuration>
                        <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
                        <animTime dataType="Float">0</animTime>
                        <customFrameSequence />
                        <firstFrame dataType="Int">0</firstFrame>
                        <frameCount dataType="Int">2</frameCount>
                        <gameobj dataType="ObjectRef">3270008394</gameobj>
                        <paused dataType="Bool">false</paused>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.CameraButton" id="1780227121">
                        <active dataType="Bool">true</active>
                        <animator />
                        <gameobj dataType="ObjectRef">3270008394</gameobj>
                        <number dataType="Int">9</number>
                        <renderer />
                        <transform />
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="2865683922">
                        <active dataType="Bool">true</active>
                        <gameobj dataType="ObjectRef">3270008394</gameobj>
                        <render />
                      </item>
                    </_items>
                    <_size dataType="Int">5</_size>
                  </compList>
                  <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="4051709822" surrogate="true">
                    <header />
                    <body>
                      <keys dataType="Array" type="System.Object[]" id="2912257696">
                        <item dataType="ObjectRef">3757206646</item>
                        <item dataType="ObjectRef">1240285980</item>
                        <item dataType="ObjectRef">1128967702</item>
                        <item dataType="ObjectRef">1180528928</item>
                        <item dataType="ObjectRef">2905165420</item>
                      </keys>
                      <values dataType="Array" type="System.Object[]" id="1408193678">
                        <item dataType="ObjectRef">3327285612</item>
                        <item dataType="ObjectRef">443660378</item>
                        <item dataType="ObjectRef">3010204934</item>
                        <item dataType="ObjectRef">2865683922</item>
                        <item dataType="ObjectRef">1780227121</item>
                      </values>
                    </body>
                  </compMap>
                  <compTransform dataType="ObjectRef">3327285612</compTransform>
                  <identifier dataType="Struct" type="System.Guid" surrogate="true">
                    <header>
                      <data dataType="Array" type="System.Byte[]" id="3098226364">7aB2wIipx0S31ocB9S7DIA==</data>
                    </header>
                    <body />
                  </identifier>
                  <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                  <name dataType="String">Cam 6</name>
                  <parent dataType="ObjectRef">2578211885</parent>
                  <prefabLink />
                </item>
                <item dataType="Struct" type="Duality.GameObject" id="1912945850">
                  <active dataType="Bool">true</active>
                  <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="1148389598">
                    <_items dataType="Array" type="Duality.GameObject[]" id="2153237264" length="4">
                      <item dataType="Struct" type="Duality.GameObject" id="2183099095">
                        <active dataType="Bool">true</active>
                        <children />
                        <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3193627539">
                          <_items dataType="Array" type="Duality.Component[]" id="4165048550" length="4">
                            <item dataType="Struct" type="Duality.Components.Transform" id="2240376313">
                              <active dataType="Bool">true</active>
                              <angle dataType="Float">0</angle>
                              <angleAbs dataType="Float">0</angleAbs>
                              <gameobj dataType="ObjectRef">2183099095</gameobj>
                              <ignoreParent dataType="Bool">false</ignoreParent>
                              <pos dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">7</X>
                                <Y dataType="Float">7</Y>
                                <Z dataType="Float">0</Z>
                              </pos>
                              <posAbs dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">912</X>
                                <Y dataType="Float">463</Y>
                                <Z dataType="Float">0</Z>
                              </posAbs>
                              <scale dataType="Float">1</scale>
                              <scaleAbs dataType="Float">1</scaleAbs>
                            </item>
                            <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3651718375">
                              <active dataType="Bool">true</active>
                              <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                                <A dataType="Byte">0</A>
                                <B dataType="Byte">255</B>
                                <G dataType="Byte">255</G>
                                <R dataType="Byte">255</R>
                              </colorTint>
                              <customMat />
                              <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                              <gameobj dataType="ObjectRef">2183099095</gameobj>
                              <offset dataType="Float">0</offset>
                              <pixelGrid dataType="Bool">false</pixelGrid>
                              <rect dataType="Struct" type="Duality.Rect">
                                <H dataType="Float">25</H>
                                <W dataType="Float">31</W>
                                <X dataType="Float">0</X>
                                <Y dataType="Float">0</Y>
                              </rect>
                              <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                              <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                                <contentPath dataType="String">Data\Camera\button\Text\1c.Material.res</contentPath>
                              </sharedMat>
                              <spriteIndex dataType="Int">-1</spriteIndex>
                              <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                            </item>
                            <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="1778774623">
                              <active dataType="Bool">true</active>
                              <gameobj dataType="ObjectRef">2183099095</gameobj>
                              <render />
                            </item>
                          </_items>
                          <_size dataType="Int">3</_size>
                        </compList>
                        <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2177353464" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="2568198649">
                              <item dataType="ObjectRef">3757206646</item>
                              <item dataType="ObjectRef">1240285980</item>
                              <item dataType="ObjectRef">1180528928</item>
                            </keys>
                            <values dataType="Array" type="System.Object[]" id="3993162880">
                              <item dataType="ObjectRef">2240376313</item>
                              <item dataType="ObjectRef">3651718375</item>
                              <item dataType="ObjectRef">1778774623</item>
                            </values>
                          </body>
                        </compMap>
                        <compTransform dataType="ObjectRef">2240376313</compTransform>
                        <identifier dataType="Struct" type="System.Guid" surrogate="true">
                          <header>
                            <data dataType="Array" type="System.Byte[]" id="2871227387">/LYH6s//u0e0YVjACACyWQ==</data>
                          </header>
                          <body />
                        </identifier>
                        <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                        <name dataType="String">text</name>
                        <parent dataType="ObjectRef">1912945850</parent>
                        <prefabLink />
                      </item>
                    </_items>
                    <_size dataType="Int">1</_size>
                  </children>
                  <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="325279498">
                    <_items dataType="Array" type="Duality.Component[]" id="213963516" length="8">
                      <item dataType="Struct" type="Duality.Components.Transform" id="1970223068">
                        <active dataType="Bool">true</active>
                        <angle dataType="Float">0</angle>
                        <angleAbs dataType="Float">0</angleAbs>
                        <gameobj dataType="ObjectRef">1912945850</gameobj>
                        <ignoreParent dataType="Bool">false</ignoreParent>
                        <pos dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">905</X>
                          <Y dataType="Float">456</Y>
                          <Z dataType="Float">0</Z>
                        </pos>
                        <posAbs dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">905</X>
                          <Y dataType="Float">456</Y>
                          <Z dataType="Float">0</Z>
                        </posAbs>
                        <scale dataType="Float">1</scale>
                        <scaleAbs dataType="Float">1</scaleAbs>
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3381565130">
                        <active dataType="Bool">true</active>
                        <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                          <A dataType="Byte">0</A>
                          <B dataType="Byte">255</B>
                          <G dataType="Byte">255</G>
                          <R dataType="Byte">255</R>
                        </colorTint>
                        <customMat />
                        <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                        <gameobj dataType="ObjectRef">1912945850</gameobj>
                        <offset dataType="Float">79</offset>
                        <pixelGrid dataType="Bool">false</pixelGrid>
                        <rect dataType="Struct" type="Duality.Rect">
                          <H dataType="Float">40</H>
                          <W dataType="Float">60</W>
                          <X dataType="Float">0</X>
                          <Y dataType="Float">0</Y>
                        </rect>
                        <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                        <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                          <contentPath dataType="String">Data\Camera\button\button.Material.res</contentPath>
                        </sharedMat>
                        <spriteIndex dataType="Int">0</spriteIndex>
                        <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="1653142390">
                        <active dataType="Bool">true</active>
                        <animDuration dataType="Float">2</animDuration>
                        <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
                        <animTime dataType="Float">0</animTime>
                        <customFrameSequence />
                        <firstFrame dataType="Int">0</firstFrame>
                        <frameCount dataType="Int">2</frameCount>
                        <gameobj dataType="ObjectRef">1912945850</gameobj>
                        <paused dataType="Bool">false</paused>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.CameraButton" id="423164577">
                        <active dataType="Bool">true</active>
                        <animator />
                        <gameobj dataType="ObjectRef">1912945850</gameobj>
                        <number dataType="Int">2</number>
                        <renderer />
                        <transform />
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="1508621378">
                        <active dataType="Bool">true</active>
                        <gameobj dataType="ObjectRef">1912945850</gameobj>
                        <render />
                      </item>
                    </_items>
                    <_size dataType="Int">5</_size>
                  </compList>
                  <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2850145070" surrogate="true">
                    <header />
                    <body>
                      <keys dataType="Array" type="System.Object[]" id="327419168">
                        <item dataType="ObjectRef">3757206646</item>
                        <item dataType="ObjectRef">1240285980</item>
                        <item dataType="ObjectRef">1128967702</item>
                        <item dataType="ObjectRef">1180528928</item>
                        <item dataType="ObjectRef">2905165420</item>
                      </keys>
                      <values dataType="Array" type="System.Object[]" id="1788510094">
                        <item dataType="ObjectRef">1970223068</item>
                        <item dataType="ObjectRef">3381565130</item>
                        <item dataType="ObjectRef">1653142390</item>
                        <item dataType="ObjectRef">1508621378</item>
                        <item dataType="ObjectRef">423164577</item>
                      </values>
                    </body>
                  </compMap>
                  <compTransform dataType="ObjectRef">1970223068</compTransform>
                  <identifier dataType="Struct" type="System.Guid" surrogate="true">
                    <header>
                      <data dataType="Array" type="System.Byte[]" id="3912539196">sgvQyF//zEqlVqULfuc1nA==</data>
                    </header>
                    <body />
                  </identifier>
                  <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                  <name dataType="String">Cam 1C</name>
                  <parent dataType="ObjectRef">2578211885</parent>
                  <prefabLink />
                </item>
                <item dataType="Struct" type="Duality.GameObject" id="2139926961">
                  <active dataType="Bool">true</active>
                  <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="2831795969">
                    <_items dataType="Array" type="Duality.GameObject[]" id="1534435630" length="4">
                      <item dataType="Struct" type="Duality.GameObject" id="1605021198">
                        <active dataType="Bool">true</active>
                        <children />
                        <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3608673794">
                          <_items dataType="Array" type="Duality.Component[]" id="3649356176" length="4">
                            <item dataType="Struct" type="Duality.Components.Transform" id="1662298416">
                              <active dataType="Bool">true</active>
                              <angle dataType="Float">0</angle>
                              <angleAbs dataType="Float">0</angleAbs>
                              <gameobj dataType="ObjectRef">1605021198</gameobj>
                              <ignoreParent dataType="Bool">false</ignoreParent>
                              <pos dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">7</X>
                                <Y dataType="Float">7</Y>
                                <Z dataType="Float">0</Z>
                              </pos>
                              <posAbs dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">964</X>
                                <Y dataType="Float">582</Y>
                                <Z dataType="Float">0</Z>
                              </posAbs>
                              <scale dataType="Float">1</scale>
                              <scaleAbs dataType="Float">1</scaleAbs>
                            </item>
                            <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3073640478">
                              <active dataType="Bool">true</active>
                              <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                                <A dataType="Byte">0</A>
                                <B dataType="Byte">255</B>
                                <G dataType="Byte">255</G>
                                <R dataType="Byte">255</R>
                              </colorTint>
                              <customMat />
                              <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                              <gameobj dataType="ObjectRef">1605021198</gameobj>
                              <offset dataType="Float">0</offset>
                              <pixelGrid dataType="Bool">false</pixelGrid>
                              <rect dataType="Struct" type="Duality.Rect">
                                <H dataType="Float">25</H>
                                <W dataType="Float">31</W>
                                <X dataType="Float">0</X>
                                <Y dataType="Float">0</Y>
                              </rect>
                              <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                              <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                                <contentPath dataType="String">Data\Camera\button\Text\2a.Material.res</contentPath>
                              </sharedMat>
                              <spriteIndex dataType="Int">-1</spriteIndex>
                              <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                            </item>
                            <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="1200696726">
                              <active dataType="Bool">true</active>
                              <gameobj dataType="ObjectRef">1605021198</gameobj>
                              <render />
                            </item>
                          </_items>
                          <_size dataType="Int">3</_size>
                        </compList>
                        <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3174047626" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="1970896344">
                              <item dataType="ObjectRef">3757206646</item>
                              <item dataType="ObjectRef">1240285980</item>
                              <item dataType="ObjectRef">1180528928</item>
                            </keys>
                            <values dataType="Array" type="System.Object[]" id="3955629726">
                              <item dataType="ObjectRef">1662298416</item>
                              <item dataType="ObjectRef">3073640478</item>
                              <item dataType="ObjectRef">1200696726</item>
                            </values>
                          </body>
                        </compMap>
                        <compTransform dataType="ObjectRef">1662298416</compTransform>
                        <identifier dataType="Struct" type="System.Guid" surrogate="true">
                          <header>
                            <data dataType="Array" type="System.Byte[]" id="1117272452">Ndm65JdNIUm/Uw9ztBSh7w==</data>
                          </header>
                          <body />
                        </identifier>
                        <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                        <name dataType="String">text</name>
                        <parent dataType="ObjectRef">2139926961</parent>
                        <prefabLink />
                      </item>
                    </_items>
                    <_size dataType="Int">1</_size>
                  </children>
                  <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1521197920">
                    <_items dataType="Array" type="Duality.Component[]" id="2908526795" length="8">
                      <item dataType="Struct" type="Duality.Components.Transform" id="2197204179">
                        <active dataType="Bool">true</active>
                        <angle dataType="Float">0</angle>
                        <angleAbs dataType="Float">0</angleAbs>
                        <gameobj dataType="ObjectRef">2139926961</gameobj>
                        <ignoreParent dataType="Bool">false</ignoreParent>
                        <pos dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">957</X>
                          <Y dataType="Float">575</Y>
                          <Z dataType="Float">0</Z>
                        </pos>
                        <posAbs dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">957</X>
                          <Y dataType="Float">575</Y>
                          <Z dataType="Float">0</Z>
                        </posAbs>
                        <scale dataType="Float">1</scale>
                        <scaleAbs dataType="Float">1</scaleAbs>
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3608546241">
                        <active dataType="Bool">true</active>
                        <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                          <A dataType="Byte">0</A>
                          <B dataType="Byte">255</B>
                          <G dataType="Byte">255</G>
                          <R dataType="Byte">255</R>
                        </colorTint>
                        <customMat />
                        <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                        <gameobj dataType="ObjectRef">2139926961</gameobj>
                        <offset dataType="Float">79</offset>
                        <pixelGrid dataType="Bool">false</pixelGrid>
                        <rect dataType="Struct" type="Duality.Rect">
                          <H dataType="Float">40</H>
                          <W dataType="Float">60</W>
                          <X dataType="Float">0</X>
                          <Y dataType="Float">0</Y>
                        </rect>
                        <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                        <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                          <contentPath dataType="String">Data\Camera\button\button.Material.res</contentPath>
                        </sharedMat>
                        <spriteIndex dataType="Int">0</spriteIndex>
                        <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="1880123501">
                        <active dataType="Bool">true</active>
                        <animDuration dataType="Float">2</animDuration>
                        <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
                        <animTime dataType="Float">0</animTime>
                        <customFrameSequence />
                        <firstFrame dataType="Int">0</firstFrame>
                        <frameCount dataType="Int">2</frameCount>
                        <gameobj dataType="ObjectRef">2139926961</gameobj>
                        <paused dataType="Bool">false</paused>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.CameraButton" id="650145688">
                        <active dataType="Bool">true</active>
                        <animator />
                        <gameobj dataType="ObjectRef">2139926961</gameobj>
                        <number dataType="Int">3</number>
                        <renderer />
                        <transform />
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="1735602489">
                        <active dataType="Bool">true</active>
                        <gameobj dataType="ObjectRef">2139926961</gameobj>
                        <render />
                      </item>
                    </_items>
                    <_size dataType="Int">5</_size>
                  </compList>
                  <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3051422547" surrogate="true">
                    <header />
                    <body>
                      <keys dataType="Array" type="System.Object[]" id="904898596">
                        <item dataType="ObjectRef">3757206646</item>
                        <item dataType="ObjectRef">1240285980</item>
                        <item dataType="ObjectRef">1128967702</item>
                        <item dataType="ObjectRef">1180528928</item>
                        <item dataType="ObjectRef">2905165420</item>
                      </keys>
                      <values dataType="Array" type="System.Object[]" id="1267714326">
                        <item dataType="ObjectRef">2197204179</item>
                        <item dataType="ObjectRef">3608546241</item>
                        <item dataType="ObjectRef">1880123501</item>
                        <item dataType="ObjectRef">1735602489</item>
                        <item dataType="ObjectRef">650145688</item>
                      </values>
                    </body>
                  </compMap>
                  <compTransform dataType="ObjectRef">2197204179</compTransform>
                  <identifier dataType="Struct" type="System.Guid" surrogate="true">
                    <header>
                      <data dataType="Array" type="System.Byte[]" id="3976761888">Ts6hDNw1xkuFqVgVeYR0zg==</data>
                    </header>
                    <body />
                  </identifier>
                  <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                  <name dataType="String">Cam 2A</name>
                  <parent dataType="ObjectRef">2578211885</parent>
                  <prefabLink />
                </item>
                <item dataType="Struct" type="Duality.GameObject" id="805991366">
                  <active dataType="Bool">true</active>
                  <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="3534482298">
                    <_items dataType="Array" type="Duality.GameObject[]" id="3082015616" length="4">
                      <item dataType="Struct" type="Duality.GameObject" id="2085367654">
                        <active dataType="Bool">true</active>
                        <children />
                        <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="795417958">
                          <_items dataType="Array" type="Duality.Component[]" id="3509320576" length="4">
                            <item dataType="Struct" type="Duality.Components.Transform" id="2142644872">
                              <active dataType="Bool">true</active>
                              <angle dataType="Float">0</angle>
                              <angleAbs dataType="Float">0</angleAbs>
                              <gameobj dataType="ObjectRef">2085367654</gameobj>
                              <ignoreParent dataType="Bool">false</ignoreParent>
                              <pos dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">7</X>
                                <Y dataType="Float">7</Y>
                                <Z dataType="Float">0</Z>
                              </pos>
                              <posAbs dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">964</X>
                                <Y dataType="Float">622</Y>
                                <Z dataType="Float">0</Z>
                              </posAbs>
                              <scale dataType="Float">1</scale>
                              <scaleAbs dataType="Float">1</scaleAbs>
                            </item>
                            <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3553986934">
                              <active dataType="Bool">true</active>
                              <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                                <A dataType="Byte">0</A>
                                <B dataType="Byte">255</B>
                                <G dataType="Byte">255</G>
                                <R dataType="Byte">255</R>
                              </colorTint>
                              <customMat />
                              <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                              <gameobj dataType="ObjectRef">2085367654</gameobj>
                              <offset dataType="Float">0</offset>
                              <pixelGrid dataType="Bool">false</pixelGrid>
                              <rect dataType="Struct" type="Duality.Rect">
                                <H dataType="Float">25</H>
                                <W dataType="Float">31</W>
                                <X dataType="Float">0</X>
                                <Y dataType="Float">0</Y>
                              </rect>
                              <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                              <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                                <contentPath dataType="String">Data\Camera\button\Text\2b.Material.res</contentPath>
                              </sharedMat>
                              <spriteIndex dataType="Int">-1</spriteIndex>
                              <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                            </item>
                            <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="1681043182">
                              <active dataType="Bool">true</active>
                              <gameobj dataType="ObjectRef">2085367654</gameobj>
                              <render />
                            </item>
                          </_items>
                          <_size dataType="Int">3</_size>
                        </compList>
                        <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="299117370" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="2246086868">
                              <item dataType="ObjectRef">3757206646</item>
                              <item dataType="ObjectRef">1240285980</item>
                              <item dataType="ObjectRef">1180528928</item>
                            </keys>
                            <values dataType="Array" type="System.Object[]" id="1185912246">
                              <item dataType="ObjectRef">2142644872</item>
                              <item dataType="ObjectRef">3553986934</item>
                              <item dataType="ObjectRef">1681043182</item>
                            </values>
                          </body>
                        </compMap>
                        <compTransform dataType="ObjectRef">2142644872</compTransform>
                        <identifier dataType="Struct" type="System.Guid" surrogate="true">
                          <header>
                            <data dataType="Array" type="System.Byte[]" id="1843586544">AsRm1GWlYUmVzQLjwUGB3A==</data>
                          </header>
                          <body />
                        </identifier>
                        <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                        <name dataType="String">text</name>
                        <parent dataType="ObjectRef">805991366</parent>
                        <prefabLink />
                      </item>
                    </_items>
                    <_size dataType="Int">1</_size>
                  </children>
                  <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1739875130">
                    <_items dataType="Array" type="Duality.Component[]" id="3734424256" length="8">
                      <item dataType="Struct" type="Duality.Components.Transform" id="863268584">
                        <active dataType="Bool">true</active>
                        <angle dataType="Float">0</angle>
                        <angleAbs dataType="Float">0</angleAbs>
                        <gameobj dataType="ObjectRef">805991366</gameobj>
                        <ignoreParent dataType="Bool">false</ignoreParent>
                        <pos dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">957</X>
                          <Y dataType="Float">615</Y>
                          <Z dataType="Float">0</Z>
                        </pos>
                        <posAbs dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">957</X>
                          <Y dataType="Float">615</Y>
                          <Z dataType="Float">0</Z>
                        </posAbs>
                        <scale dataType="Float">1</scale>
                        <scaleAbs dataType="Float">1</scaleAbs>
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2274610646">
                        <active dataType="Bool">true</active>
                        <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                          <A dataType="Byte">0</A>
                          <B dataType="Byte">255</B>
                          <G dataType="Byte">255</G>
                          <R dataType="Byte">255</R>
                        </colorTint>
                        <customMat />
                        <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                        <gameobj dataType="ObjectRef">805991366</gameobj>
                        <offset dataType="Float">79</offset>
                        <pixelGrid dataType="Bool">false</pixelGrid>
                        <rect dataType="Struct" type="Duality.Rect">
                          <H dataType="Float">40</H>
                          <W dataType="Float">60</W>
                          <X dataType="Float">0</X>
                          <Y dataType="Float">0</Y>
                        </rect>
                        <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                        <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                          <contentPath dataType="String">Data\Camera\button\button.Material.res</contentPath>
                        </sharedMat>
                        <spriteIndex dataType="Int">0</spriteIndex>
                        <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="546187906">
                        <active dataType="Bool">true</active>
                        <animDuration dataType="Float">2</animDuration>
                        <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
                        <animTime dataType="Float">0</animTime>
                        <customFrameSequence />
                        <firstFrame dataType="Int">0</firstFrame>
                        <frameCount dataType="Int">2</frameCount>
                        <gameobj dataType="ObjectRef">805991366</gameobj>
                        <paused dataType="Bool">false</paused>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.CameraButton" id="3611177389">
                        <active dataType="Bool">true</active>
                        <animator />
                        <gameobj dataType="ObjectRef">805991366</gameobj>
                        <number dataType="Int">4</number>
                        <renderer />
                        <transform />
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="401666894">
                        <active dataType="Bool">true</active>
                        <gameobj dataType="ObjectRef">805991366</gameobj>
                        <render />
                      </item>
                    </_items>
                    <_size dataType="Int">5</_size>
                  </compList>
                  <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="664580090" surrogate="true">
                    <header />
                    <body>
                      <keys dataType="Array" type="System.Object[]" id="672872192">
                        <item dataType="ObjectRef">3757206646</item>
                        <item dataType="ObjectRef">1240285980</item>
                        <item dataType="ObjectRef">1128967702</item>
                        <item dataType="ObjectRef">1180528928</item>
                        <item dataType="ObjectRef">2905165420</item>
                      </keys>
                      <values dataType="Array" type="System.Object[]" id="3500628430">
                        <item dataType="ObjectRef">863268584</item>
                        <item dataType="ObjectRef">2274610646</item>
                        <item dataType="ObjectRef">546187906</item>
                        <item dataType="ObjectRef">401666894</item>
                        <item dataType="ObjectRef">3611177389</item>
                      </values>
                    </body>
                  </compMap>
                  <compTransform dataType="ObjectRef">863268584</compTransform>
                  <identifier dataType="Struct" type="System.Guid" surrogate="true">
                    <header>
                      <data dataType="Array" type="System.Byte[]" id="4101845404">Sicr7qYhRUCYgS41sZmo3g==</data>
                    </header>
                    <body />
                  </identifier>
                  <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                  <name dataType="String">Cam 2B</name>
                  <parent dataType="ObjectRef">2578211885</parent>
                  <prefabLink />
                </item>
                <item dataType="Struct" type="Duality.GameObject" id="2645946997">
                  <active dataType="Bool">true</active>
                  <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="2302115765">
                    <_items dataType="Array" type="Duality.GameObject[]" id="3643379446" length="4">
                      <item dataType="Struct" type="Duality.GameObject" id="1377852436">
                        <active dataType="Bool">true</active>
                        <children />
                        <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1394942992">
                          <_items dataType="Array" type="Duality.Component[]" id="2772879164" length="4">
                            <item dataType="Struct" type="Duality.Components.Transform" id="1435129654">
                              <active dataType="Bool">true</active>
                              <angle dataType="Float">0</angle>
                              <angleAbs dataType="Float">0</angleAbs>
                              <gameobj dataType="ObjectRef">1377852436</gameobj>
                              <ignoreParent dataType="Bool">false</ignoreParent>
                              <pos dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">7</X>
                                <Y dataType="Float">7</Y>
                                <Z dataType="Float">0</Z>
                              </pos>
                              <posAbs dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">878</X>
                                <Y dataType="Float">555</Y>
                                <Z dataType="Float">0</Z>
                              </posAbs>
                              <scale dataType="Float">1</scale>
                              <scaleAbs dataType="Float">1</scaleAbs>
                            </item>
                            <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2846471716">
                              <active dataType="Bool">true</active>
                              <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                                <A dataType="Byte">0</A>
                                <B dataType="Byte">255</B>
                                <G dataType="Byte">255</G>
                                <R dataType="Byte">255</R>
                              </colorTint>
                              <customMat />
                              <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                              <gameobj dataType="ObjectRef">1377852436</gameobj>
                              <offset dataType="Float">0</offset>
                              <pixelGrid dataType="Bool">false</pixelGrid>
                              <rect dataType="Struct" type="Duality.Rect">
                                <H dataType="Float">25</H>
                                <W dataType="Float">31</W>
                                <X dataType="Float">0</X>
                                <Y dataType="Float">0</Y>
                              </rect>
                              <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                              <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                                <contentPath dataType="String">Data\Camera\button\Text\3.Material.res</contentPath>
                              </sharedMat>
                              <spriteIndex dataType="Int">-1</spriteIndex>
                              <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                            </item>
                            <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="973527964">
                              <active dataType="Bool">true</active>
                              <gameobj dataType="ObjectRef">1377852436</gameobj>
                              <render />
                            </item>
                          </_items>
                          <_size dataType="Int">3</_size>
                        </compList>
                        <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3035495662" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="548213858">
                              <item dataType="ObjectRef">3757206646</item>
                              <item dataType="ObjectRef">1240285980</item>
                              <item dataType="ObjectRef">1180528928</item>
                            </keys>
                            <values dataType="Array" type="System.Object[]" id="157135242">
                              <item dataType="ObjectRef">1435129654</item>
                              <item dataType="ObjectRef">2846471716</item>
                              <item dataType="ObjectRef">973527964</item>
                            </values>
                          </body>
                        </compMap>
                        <compTransform dataType="ObjectRef">1435129654</compTransform>
                        <identifier dataType="Struct" type="System.Guid" surrogate="true">
                          <header>
                            <data dataType="Array" type="System.Byte[]" id="4078950802">uVkjAzsNOEyTzk9d94/U8Q==</data>
                          </header>
                          <body />
                        </identifier>
                        <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                        <name dataType="String">text</name>
                        <parent dataType="ObjectRef">2645946997</parent>
                        <prefabLink />
                      </item>
                    </_items>
                    <_size dataType="Int">1</_size>
                  </children>
                  <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2511440712">
                    <_items dataType="Array" type="Duality.Component[]" id="3993007519" length="8">
                      <item dataType="Struct" type="Duality.Components.Transform" id="2703224215">
                        <active dataType="Bool">true</active>
                        <angle dataType="Float">0</angle>
                        <angleAbs dataType="Float">0</angleAbs>
                        <gameobj dataType="ObjectRef">2645946997</gameobj>
                        <ignoreParent dataType="Bool">false</ignoreParent>
                        <pos dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">871</X>
                          <Y dataType="Float">548</Y>
                          <Z dataType="Float">0</Z>
                        </pos>
                        <posAbs dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">871</X>
                          <Y dataType="Float">548</Y>
                          <Z dataType="Float">0</Z>
                        </posAbs>
                        <scale dataType="Float">1</scale>
                        <scaleAbs dataType="Float">1</scaleAbs>
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="4114566277">
                        <active dataType="Bool">true</active>
                        <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                          <A dataType="Byte">0</A>
                          <B dataType="Byte">255</B>
                          <G dataType="Byte">255</G>
                          <R dataType="Byte">255</R>
                        </colorTint>
                        <customMat />
                        <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                        <gameobj dataType="ObjectRef">2645946997</gameobj>
                        <offset dataType="Float">79</offset>
                        <pixelGrid dataType="Bool">false</pixelGrid>
                        <rect dataType="Struct" type="Duality.Rect">
                          <H dataType="Float">40</H>
                          <W dataType="Float">60</W>
                          <X dataType="Float">0</X>
                          <Y dataType="Float">0</Y>
                        </rect>
                        <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                        <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                          <contentPath dataType="String">Data\Camera\button\button.Material.res</contentPath>
                        </sharedMat>
                        <spriteIndex dataType="Int">0</spriteIndex>
                        <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="2386143537">
                        <active dataType="Bool">true</active>
                        <animDuration dataType="Float">2</animDuration>
                        <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
                        <animTime dataType="Float">0</animTime>
                        <customFrameSequence />
                        <firstFrame dataType="Int">0</firstFrame>
                        <frameCount dataType="Int">2</frameCount>
                        <gameobj dataType="ObjectRef">2645946997</gameobj>
                        <paused dataType="Bool">false</paused>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.CameraButton" id="1156165724">
                        <active dataType="Bool">true</active>
                        <animator />
                        <gameobj dataType="ObjectRef">2645946997</gameobj>
                        <number dataType="Int">5</number>
                        <renderer />
                        <transform />
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="2241622525">
                        <active dataType="Bool">true</active>
                        <gameobj dataType="ObjectRef">2645946997</gameobj>
                        <render />
                      </item>
                    </_items>
                    <_size dataType="Int">5</_size>
                  </compList>
                  <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3604094719" surrogate="true">
                    <header />
                    <body>
                      <keys dataType="Array" type="System.Object[]" id="91889988">
                        <item dataType="ObjectRef">3757206646</item>
                        <item dataType="ObjectRef">1240285980</item>
                        <item dataType="ObjectRef">1128967702</item>
                        <item dataType="ObjectRef">1180528928</item>
                        <item dataType="ObjectRef">2905165420</item>
                      </keys>
                      <values dataType="Array" type="System.Object[]" id="3048813206">
                        <item dataType="ObjectRef">2703224215</item>
                        <item dataType="ObjectRef">4114566277</item>
                        <item dataType="ObjectRef">2386143537</item>
                        <item dataType="ObjectRef">2241622525</item>
                        <item dataType="ObjectRef">1156165724</item>
                      </values>
                    </body>
                  </compMap>
                  <compTransform dataType="ObjectRef">2703224215</compTransform>
                  <identifier dataType="Struct" type="System.Guid" surrogate="true">
                    <header>
                      <data dataType="Array" type="System.Byte[]" id="1727426816">ihawAn5gr0G264rqAliV8Q==</data>
                    </header>
                    <body />
                  </identifier>
                  <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                  <name dataType="String">Cam 3</name>
                  <parent dataType="ObjectRef">2578211885</parent>
                  <prefabLink />
                </item>
                <item dataType="Struct" type="Duality.GameObject" id="3026069331">
                  <active dataType="Bool">true</active>
                  <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="3784280883">
                    <_items dataType="Array" type="Duality.GameObject[]" id="475721766" length="4">
                      <item dataType="Struct" type="Duality.GameObject" id="3697224140">
                        <active dataType="Bool">true</active>
                        <children />
                        <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1459713512">
                          <_items dataType="Array" type="Duality.Component[]" id="3692031020" length="4">
                            <item dataType="Struct" type="Duality.Components.Transform" id="3754501358">
                              <active dataType="Bool">true</active>
                              <angle dataType="Float">0</angle>
                              <angleAbs dataType="Float">0</angleAbs>
                              <gameobj dataType="ObjectRef">3697224140</gameobj>
                              <ignoreParent dataType="Bool">false</ignoreParent>
                              <pos dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">7</X>
                                <Y dataType="Float">7</Y>
                                <Z dataType="Float">0</Z>
                              </pos>
                              <posAbs dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">1067</X>
                                <Y dataType="Float">582</Y>
                                <Z dataType="Float">0</Z>
                              </posAbs>
                              <scale dataType="Float">1</scale>
                              <scaleAbs dataType="Float">1</scaleAbs>
                            </item>
                            <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="870876124">
                              <active dataType="Bool">true</active>
                              <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                                <A dataType="Byte">0</A>
                                <B dataType="Byte">255</B>
                                <G dataType="Byte">255</G>
                                <R dataType="Byte">255</R>
                              </colorTint>
                              <customMat />
                              <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                              <gameobj dataType="ObjectRef">3697224140</gameobj>
                              <offset dataType="Float">0</offset>
                              <pixelGrid dataType="Bool">false</pixelGrid>
                              <rect dataType="Struct" type="Duality.Rect">
                                <H dataType="Float">25</H>
                                <W dataType="Float">31</W>
                                <X dataType="Float">0</X>
                                <Y dataType="Float">0</Y>
                              </rect>
                              <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                              <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                                <contentPath dataType="String">Data\Camera\button\Text\4a.Material.res</contentPath>
                              </sharedMat>
                              <spriteIndex dataType="Int">-1</spriteIndex>
                              <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                            </item>
                            <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="3292899668">
                              <active dataType="Bool">true</active>
                              <gameobj dataType="ObjectRef">3697224140</gameobj>
                              <render />
                            </item>
                          </_items>
                          <_size dataType="Int">3</_size>
                        </compList>
                        <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2023015198" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="1925630634">
                              <item dataType="ObjectRef">3757206646</item>
                              <item dataType="ObjectRef">1240285980</item>
                              <item dataType="ObjectRef">1180528928</item>
                            </keys>
                            <values dataType="Array" type="System.Object[]" id="840904922">
                              <item dataType="ObjectRef">3754501358</item>
                              <item dataType="ObjectRef">870876124</item>
                              <item dataType="ObjectRef">3292899668</item>
                            </values>
                          </body>
                        </compMap>
                        <compTransform dataType="ObjectRef">3754501358</compTransform>
                        <identifier dataType="Struct" type="System.Guid" surrogate="true">
                          <header>
                            <data dataType="Array" type="System.Byte[]" id="308474506">P7pwPDj9Kk+PFX/55po7og==</data>
                          </header>
                          <body />
                        </identifier>
                        <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                        <name dataType="String">text</name>
                        <parent dataType="ObjectRef">3026069331</parent>
                        <prefabLink />
                      </item>
                    </_items>
                    <_size dataType="Int">1</_size>
                  </children>
                  <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2411336376">
                    <_items dataType="Array" type="Duality.Component[]" id="2556850521" length="8">
                      <item dataType="Struct" type="Duality.Components.Transform" id="3083346549">
                        <active dataType="Bool">true</active>
                        <angle dataType="Float">0</angle>
                        <angleAbs dataType="Float">0</angleAbs>
                        <gameobj dataType="ObjectRef">3026069331</gameobj>
                        <ignoreParent dataType="Bool">false</ignoreParent>
                        <pos dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">1060</X>
                          <Y dataType="Float">575</Y>
                          <Z dataType="Float">0</Z>
                        </pos>
                        <posAbs dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">1060</X>
                          <Y dataType="Float">575</Y>
                          <Z dataType="Float">0</Z>
                        </posAbs>
                        <scale dataType="Float">1</scale>
                        <scaleAbs dataType="Float">1</scaleAbs>
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="199721315">
                        <active dataType="Bool">true</active>
                        <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                          <A dataType="Byte">0</A>
                          <B dataType="Byte">255</B>
                          <G dataType="Byte">255</G>
                          <R dataType="Byte">255</R>
                        </colorTint>
                        <customMat />
                        <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                        <gameobj dataType="ObjectRef">3026069331</gameobj>
                        <offset dataType="Float">79</offset>
                        <pixelGrid dataType="Bool">false</pixelGrid>
                        <rect dataType="Struct" type="Duality.Rect">
                          <H dataType="Float">40</H>
                          <W dataType="Float">60</W>
                          <X dataType="Float">0</X>
                          <Y dataType="Float">0</Y>
                        </rect>
                        <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                        <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                          <contentPath dataType="String">Data\Camera\button\button.Material.res</contentPath>
                        </sharedMat>
                        <spriteIndex dataType="Int">0</spriteIndex>
                        <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="2766265871">
                        <active dataType="Bool">true</active>
                        <animDuration dataType="Float">2</animDuration>
                        <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
                        <animTime dataType="Float">0</animTime>
                        <customFrameSequence />
                        <firstFrame dataType="Int">0</firstFrame>
                        <frameCount dataType="Int">2</frameCount>
                        <gameobj dataType="ObjectRef">3026069331</gameobj>
                        <paused dataType="Bool">false</paused>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.CameraButton" id="1536288058">
                        <active dataType="Bool">true</active>
                        <animator />
                        <gameobj dataType="ObjectRef">3026069331</gameobj>
                        <number dataType="Int">6</number>
                        <renderer />
                        <transform />
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="2621744859">
                        <active dataType="Bool">true</active>
                        <gameobj dataType="ObjectRef">3026069331</gameobj>
                        <render />
                      </item>
                    </_items>
                    <_size dataType="Int">5</_size>
                  </compList>
                  <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="4242876761" surrogate="true">
                    <header />
                    <body>
                      <keys dataType="Array" type="System.Object[]" id="1472873620">
                        <item dataType="ObjectRef">3757206646</item>
                        <item dataType="ObjectRef">1240285980</item>
                        <item dataType="ObjectRef">1128967702</item>
                        <item dataType="ObjectRef">1180528928</item>
                        <item dataType="ObjectRef">2905165420</item>
                      </keys>
                      <values dataType="Array" type="System.Object[]" id="2483735606">
                        <item dataType="ObjectRef">3083346549</item>
                        <item dataType="ObjectRef">199721315</item>
                        <item dataType="ObjectRef">2766265871</item>
                        <item dataType="ObjectRef">2621744859</item>
                        <item dataType="ObjectRef">1536288058</item>
                      </values>
                    </body>
                  </compMap>
                  <compTransform dataType="ObjectRef">3083346549</compTransform>
                  <identifier dataType="Struct" type="System.Guid" surrogate="true">
                    <header>
                      <data dataType="Array" type="System.Byte[]" id="326350128">2A3atU8J3kmQ2PiRLQR3Ww==</data>
                    </header>
                    <body />
                  </identifier>
                  <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                  <name dataType="String">Cam 4A</name>
                  <parent dataType="ObjectRef">2578211885</parent>
                  <prefabLink />
                </item>
                <item dataType="Struct" type="Duality.GameObject" id="1073131587">
                  <active dataType="Bool">true</active>
                  <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="943998787">
                    <_items dataType="Array" type="Duality.GameObject[]" id="1621962278" length="4">
                      <item dataType="Struct" type="Duality.GameObject" id="3657089679">
                        <active dataType="Bool">true</active>
                        <children />
                        <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1730590031">
                          <_items dataType="Array" type="Duality.Component[]" id="257920558" length="4">
                            <item dataType="Struct" type="Duality.Components.Transform" id="3714366897">
                              <active dataType="Bool">true</active>
                              <angle dataType="Float">0</angle>
                              <angleAbs dataType="Float">0</angleAbs>
                              <gameobj dataType="ObjectRef">3657089679</gameobj>
                              <ignoreParent dataType="Bool">false</ignoreParent>
                              <pos dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">7</X>
                                <Y dataType="Float">7</Y>
                                <Z dataType="Float">0</Z>
                              </pos>
                              <posAbs dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">1067</X>
                                <Y dataType="Float">622</Y>
                                <Z dataType="Float">0</Z>
                              </posAbs>
                              <scale dataType="Float">1</scale>
                              <scaleAbs dataType="Float">1</scaleAbs>
                            </item>
                            <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="830741663">
                              <active dataType="Bool">true</active>
                              <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                                <A dataType="Byte">0</A>
                                <B dataType="Byte">255</B>
                                <G dataType="Byte">255</G>
                                <R dataType="Byte">255</R>
                              </colorTint>
                              <customMat />
                              <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                              <gameobj dataType="ObjectRef">3657089679</gameobj>
                              <offset dataType="Float">0</offset>
                              <pixelGrid dataType="Bool">false</pixelGrid>
                              <rect dataType="Struct" type="Duality.Rect">
                                <H dataType="Float">25</H>
                                <W dataType="Float">31</W>
                                <X dataType="Float">0</X>
                                <Y dataType="Float">0</Y>
                              </rect>
                              <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                              <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                                <contentPath dataType="String">Data\Camera\button\Text\4b.Material.res</contentPath>
                              </sharedMat>
                              <spriteIndex dataType="Int">-1</spriteIndex>
                              <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                            </item>
                            <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="3252765207">
                              <active dataType="Bool">true</active>
                              <gameobj dataType="ObjectRef">3657089679</gameobj>
                              <render />
                            </item>
                          </_items>
                          <_size dataType="Int">3</_size>
                        </compList>
                        <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3709608032" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="52910181">
                              <item dataType="ObjectRef">3757206646</item>
                              <item dataType="ObjectRef">1240285980</item>
                              <item dataType="ObjectRef">1180528928</item>
                            </keys>
                            <values dataType="Array" type="System.Object[]" id="927631976">
                              <item dataType="ObjectRef">3714366897</item>
                              <item dataType="ObjectRef">830741663</item>
                              <item dataType="ObjectRef">3252765207</item>
                            </values>
                          </body>
                        </compMap>
                        <compTransform dataType="ObjectRef">3714366897</compTransform>
                        <identifier dataType="Struct" type="System.Guid" surrogate="true">
                          <header>
                            <data dataType="Array" type="System.Byte[]" id="2334432175">4wki3e1noku2ShFjjOG8Eg==</data>
                          </header>
                          <body />
                        </identifier>
                        <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                        <name dataType="String">text</name>
                        <parent dataType="ObjectRef">1073131587</parent>
                        <prefabLink />
                      </item>
                    </_items>
                    <_size dataType="Int">1</_size>
                  </children>
                  <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2180932792">
                    <_items dataType="Array" type="Duality.Component[]" id="2785399337" length="8">
                      <item dataType="Struct" type="Duality.Components.Transform" id="1130408805">
                        <active dataType="Bool">true</active>
                        <angle dataType="Float">0</angle>
                        <angleAbs dataType="Float">0</angleAbs>
                        <gameobj dataType="ObjectRef">1073131587</gameobj>
                        <ignoreParent dataType="Bool">false</ignoreParent>
                        <pos dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">1060</X>
                          <Y dataType="Float">615</Y>
                          <Z dataType="Float">0</Z>
                        </pos>
                        <posAbs dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">1060</X>
                          <Y dataType="Float">615</Y>
                          <Z dataType="Float">0</Z>
                        </posAbs>
                        <scale dataType="Float">1</scale>
                        <scaleAbs dataType="Float">1</scaleAbs>
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2541750867">
                        <active dataType="Bool">true</active>
                        <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                          <A dataType="Byte">0</A>
                          <B dataType="Byte">255</B>
                          <G dataType="Byte">255</G>
                          <R dataType="Byte">255</R>
                        </colorTint>
                        <customMat />
                        <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                        <gameobj dataType="ObjectRef">1073131587</gameobj>
                        <offset dataType="Float">79</offset>
                        <pixelGrid dataType="Bool">false</pixelGrid>
                        <rect dataType="Struct" type="Duality.Rect">
                          <H dataType="Float">40</H>
                          <W dataType="Float">60</W>
                          <X dataType="Float">0</X>
                          <Y dataType="Float">0</Y>
                        </rect>
                        <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                        <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                          <contentPath dataType="String">Data\Camera\button\button.Material.res</contentPath>
                        </sharedMat>
                        <spriteIndex dataType="Int">0</spriteIndex>
                        <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="813328127">
                        <active dataType="Bool">true</active>
                        <animDuration dataType="Float">2</animDuration>
                        <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
                        <animTime dataType="Float">0</animTime>
                        <customFrameSequence />
                        <firstFrame dataType="Int">0</firstFrame>
                        <frameCount dataType="Int">2</frameCount>
                        <gameobj dataType="ObjectRef">1073131587</gameobj>
                        <paused dataType="Bool">false</paused>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.CameraButton" id="3878317610">
                        <active dataType="Bool">true</active>
                        <animator />
                        <gameobj dataType="ObjectRef">1073131587</gameobj>
                        <number dataType="Int">7</number>
                        <renderer />
                        <transform />
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="668807115">
                        <active dataType="Bool">true</active>
                        <gameobj dataType="ObjectRef">1073131587</gameobj>
                        <render />
                      </item>
                    </_items>
                    <_size dataType="Int">5</_size>
                  </compList>
                  <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2565754729" surrogate="true">
                    <header />
                    <body>
                      <keys dataType="Array" type="System.Object[]" id="1068947412">
                        <item dataType="ObjectRef">3757206646</item>
                        <item dataType="ObjectRef">1240285980</item>
                        <item dataType="ObjectRef">1128967702</item>
                        <item dataType="ObjectRef">1180528928</item>
                        <item dataType="ObjectRef">2905165420</item>
                      </keys>
                      <values dataType="Array" type="System.Object[]" id="132060086">
                        <item dataType="ObjectRef">1130408805</item>
                        <item dataType="ObjectRef">2541750867</item>
                        <item dataType="ObjectRef">813328127</item>
                        <item dataType="ObjectRef">668807115</item>
                        <item dataType="ObjectRef">3878317610</item>
                      </values>
                    </body>
                  </compMap>
                  <compTransform dataType="ObjectRef">1130408805</compTransform>
                  <identifier dataType="Struct" type="System.Guid" surrogate="true">
                    <header>
                      <data dataType="Array" type="System.Byte[]" id="1805825776">4/BLV1w79ES2oorKhU1w1Q==</data>
                    </header>
                    <body />
                  </identifier>
                  <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                  <name dataType="String">Cam 4B</name>
                  <parent dataType="ObjectRef">2578211885</parent>
                  <prefabLink />
                </item>
                <item dataType="Struct" type="Duality.GameObject" id="2480585226">
                  <active dataType="Bool">true</active>
                  <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="2994592526">
                    <_items dataType="Array" type="Duality.GameObject[]" id="1197866448" length="4">
                      <item dataType="Struct" type="Duality.GameObject" id="4239293993">
                        <active dataType="Bool">true</active>
                        <children />
                        <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1286682093">
                          <_items dataType="Array" type="Duality.Component[]" id="2994393830" length="4">
                            <item dataType="Struct" type="Duality.Components.Transform" id="1603915">
                              <active dataType="Bool">true</active>
                              <angle dataType="Float">0</angle>
                              <angleAbs dataType="Float">0</angleAbs>
                              <gameobj dataType="ObjectRef">4239293993</gameobj>
                              <ignoreParent dataType="Bool">false</ignoreParent>
                              <pos dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">7</X>
                                <Y dataType="Float">7</Y>
                                <Z dataType="Float">0</Z>
                              </pos>
                              <posAbs dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">839</X>
                                <Y dataType="Float">411</Y>
                                <Z dataType="Float">0</Z>
                              </posAbs>
                              <scale dataType="Float">1</scale>
                              <scaleAbs dataType="Float">1</scaleAbs>
                            </item>
                            <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="1412945977">
                              <active dataType="Bool">true</active>
                              <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                                <A dataType="Byte">0</A>
                                <B dataType="Byte">255</B>
                                <G dataType="Byte">255</G>
                                <R dataType="Byte">255</R>
                              </colorTint>
                              <customMat />
                              <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                              <gameobj dataType="ObjectRef">4239293993</gameobj>
                              <offset dataType="Float">0</offset>
                              <pixelGrid dataType="Bool">false</pixelGrid>
                              <rect dataType="Struct" type="Duality.Rect">
                                <H dataType="Float">25</H>
                                <W dataType="Float">31</W>
                                <X dataType="Float">0</X>
                                <Y dataType="Float">0</Y>
                              </rect>
                              <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                              <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                                <contentPath dataType="String">Data\Camera\button\Text\5.Material.res</contentPath>
                              </sharedMat>
                              <spriteIndex dataType="Int">-1</spriteIndex>
                              <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                            </item>
                            <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="3834969521">
                              <active dataType="Bool">true</active>
                              <gameobj dataType="ObjectRef">4239293993</gameobj>
                              <render />
                            </item>
                          </_items>
                          <_size dataType="Int">3</_size>
                        </compList>
                        <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3576800504" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="2319881607">
                              <item dataType="ObjectRef">3757206646</item>
                              <item dataType="ObjectRef">1240285980</item>
                              <item dataType="ObjectRef">1180528928</item>
                            </keys>
                            <values dataType="Array" type="System.Object[]" id="966090112">
                              <item dataType="ObjectRef">1603915</item>
                              <item dataType="ObjectRef">1412945977</item>
                              <item dataType="ObjectRef">3834969521</item>
                            </values>
                          </body>
                        </compMap>
                        <compTransform dataType="ObjectRef">1603915</compTransform>
                        <identifier dataType="Struct" type="System.Guid" surrogate="true">
                          <header>
                            <data dataType="Array" type="System.Byte[]" id="2292650117">pfUteAIc80ucfvMsrWRcJA==</data>
                          </header>
                          <body />
                        </identifier>
                        <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                        <name dataType="String">text</name>
                        <parent dataType="ObjectRef">2480585226</parent>
                        <prefabLink />
                      </item>
                    </_items>
                    <_size dataType="Int">1</_size>
                  </children>
                  <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="189825354">
                    <_items dataType="Array" type="Duality.Component[]" id="1079414476" length="8">
                      <item dataType="Struct" type="Duality.Components.Transform" id="2537862444">
                        <active dataType="Bool">true</active>
                        <angle dataType="Float">0</angle>
                        <angleAbs dataType="Float">0</angleAbs>
                        <gameobj dataType="ObjectRef">2480585226</gameobj>
                        <ignoreParent dataType="Bool">false</ignoreParent>
                        <pos dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">832</X>
                          <Y dataType="Float">404</Y>
                          <Z dataType="Float">0</Z>
                        </pos>
                        <posAbs dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">832</X>
                          <Y dataType="Float">404</Y>
                          <Z dataType="Float">0</Z>
                        </posAbs>
                        <scale dataType="Float">1</scale>
                        <scaleAbs dataType="Float">1</scaleAbs>
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3949204506">
                        <active dataType="Bool">true</active>
                        <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                          <A dataType="Byte">0</A>
                          <B dataType="Byte">255</B>
                          <G dataType="Byte">255</G>
                          <R dataType="Byte">255</R>
                        </colorTint>
                        <customMat />
                        <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                        <gameobj dataType="ObjectRef">2480585226</gameobj>
                        <offset dataType="Float">79</offset>
                        <pixelGrid dataType="Bool">false</pixelGrid>
                        <rect dataType="Struct" type="Duality.Rect">
                          <H dataType="Float">40</H>
                          <W dataType="Float">60</W>
                          <X dataType="Float">0</X>
                          <Y dataType="Float">0</Y>
                        </rect>
                        <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                        <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                          <contentPath dataType="String">Data\Camera\button\button.Material.res</contentPath>
                        </sharedMat>
                        <spriteIndex dataType="Int">0</spriteIndex>
                        <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="2220781766">
                        <active dataType="Bool">true</active>
                        <animDuration dataType="Float">2</animDuration>
                        <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
                        <animTime dataType="Float">0</animTime>
                        <customFrameSequence />
                        <firstFrame dataType="Int">0</firstFrame>
                        <frameCount dataType="Int">2</frameCount>
                        <gameobj dataType="ObjectRef">2480585226</gameobj>
                        <paused dataType="Bool">false</paused>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.CameraButton" id="990803953">
                        <active dataType="Bool">true</active>
                        <animator />
                        <gameobj dataType="ObjectRef">2480585226</gameobj>
                        <number dataType="Int">8</number>
                        <renderer />
                        <transform />
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="2076260754">
                        <active dataType="Bool">true</active>
                        <gameobj dataType="ObjectRef">2480585226</gameobj>
                        <render />
                      </item>
                    </_items>
                    <_size dataType="Int">5</_size>
                  </compList>
                  <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="891144254" surrogate="true">
                    <header />
                    <body>
                      <keys dataType="Array" type="System.Object[]" id="1671627040">
                        <item dataType="ObjectRef">3757206646</item>
                        <item dataType="ObjectRef">1240285980</item>
                        <item dataType="ObjectRef">1128967702</item>
                        <item dataType="ObjectRef">1180528928</item>
                        <item dataType="ObjectRef">2905165420</item>
                      </keys>
                      <values dataType="Array" type="System.Object[]" id="1811640206">
                        <item dataType="ObjectRef">2537862444</item>
                        <item dataType="ObjectRef">3949204506</item>
                        <item dataType="ObjectRef">2220781766</item>
                        <item dataType="ObjectRef">2076260754</item>
                        <item dataType="ObjectRef">990803953</item>
                      </values>
                    </body>
                  </compMap>
                  <compTransform dataType="ObjectRef">2537862444</compTransform>
                  <identifier dataType="Struct" type="System.Guid" surrogate="true">
                    <header>
                      <data dataType="Array" type="System.Byte[]" id="4007643196">ypOkjRQ7jUuQKE9/tMnSOA==</data>
                    </header>
                    <body />
                  </identifier>
                  <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                  <name dataType="String">Cam 5</name>
                  <parent dataType="ObjectRef">2578211885</parent>
                  <prefabLink />
                </item>
                <item dataType="Struct" type="Duality.GameObject" id="3607111864">
                  <active dataType="Bool">true</active>
                  <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="3698062500">
                    <_items dataType="Array" type="Duality.GameObject[]" id="2185869508" length="4">
                      <item dataType="Struct" type="Duality.GameObject" id="4139811160">
                        <active dataType="Bool">true</active>
                        <children />
                        <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3941963472">
                          <_items dataType="Array" type="Duality.Component[]" id="476292796" length="4">
                            <item dataType="Struct" type="Duality.Components.Transform" id="4197088378">
                              <active dataType="Bool">true</active>
                              <angle dataType="Float">0</angle>
                              <angleAbs dataType="Float">0</angleAbs>
                              <gameobj dataType="ObjectRef">4139811160</gameobj>
                              <ignoreParent dataType="Bool">false</ignoreParent>
                              <pos dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">7</X>
                                <Y dataType="Float">7</Y>
                                <Z dataType="Float">0</Z>
                              </pos>
                              <posAbs dataType="Struct" type="Duality.Vector3">
                                <X dataType="Float">1174</X>
                                <Y dataType="Float">414</Y>
                                <Z dataType="Float">0</Z>
                              </posAbs>
                              <scale dataType="Float">1</scale>
                              <scaleAbs dataType="Float">1</scaleAbs>
                            </item>
                            <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="1313463144">
                              <active dataType="Bool">true</active>
                              <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                                <A dataType="Byte">0</A>
                                <B dataType="Byte">255</B>
                                <G dataType="Byte">255</G>
                                <R dataType="Byte">255</R>
                              </colorTint>
                              <customMat />
                              <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                              <gameobj dataType="ObjectRef">4139811160</gameobj>
                              <offset dataType="Float">0</offset>
                              <pixelGrid dataType="Bool">false</pixelGrid>
                              <rect dataType="Struct" type="Duality.Rect">
                                <H dataType="Float">25</H>
                                <W dataType="Float">31</W>
                                <X dataType="Float">0</X>
                                <Y dataType="Float">0</Y>
                              </rect>
                              <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                              <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                                <contentPath dataType="String">Data\Camera\button\Text\7.Material.res</contentPath>
                              </sharedMat>
                              <spriteIndex dataType="Int">-1</spriteIndex>
                              <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                            </item>
                            <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="3735486688">
                              <active dataType="Bool">true</active>
                              <gameobj dataType="ObjectRef">4139811160</gameobj>
                              <render />
                            </item>
                          </_items>
                          <_size dataType="Int">3</_size>
                        </compList>
                        <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="680824430" surrogate="true">
                          <header />
                          <body>
                            <keys dataType="Array" type="System.Object[]" id="3111953826">
                              <item dataType="ObjectRef">3757206646</item>
                              <item dataType="ObjectRef">1240285980</item>
                              <item dataType="ObjectRef">1180528928</item>
                            </keys>
                            <values dataType="Array" type="System.Object[]" id="3811111178">
                              <item dataType="ObjectRef">4197088378</item>
                              <item dataType="ObjectRef">1313463144</item>
                              <item dataType="ObjectRef">3735486688</item>
                            </values>
                          </body>
                        </compMap>
                        <compTransform dataType="ObjectRef">4197088378</compTransform>
                        <identifier dataType="Struct" type="System.Guid" surrogate="true">
                          <header>
                            <data dataType="Array" type="System.Byte[]" id="3560422482">o0dcZxnWG0GdgTTbKJFX9w==</data>
                          </header>
                          <body />
                        </identifier>
                        <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                        <name dataType="String">text</name>
                        <parent dataType="ObjectRef">3607111864</parent>
                        <prefabLink />
                      </item>
                    </_items>
                    <_size dataType="Int">1</_size>
                  </children>
                  <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2761786134">
                    <_items dataType="Array" type="Duality.Component[]" id="2323358446" length="8">
                      <item dataType="Struct" type="Duality.Components.Transform" id="3664389082">
                        <active dataType="Bool">true</active>
                        <angle dataType="Float">0</angle>
                        <angleAbs dataType="Float">0</angleAbs>
                        <gameobj dataType="ObjectRef">3607111864</gameobj>
                        <ignoreParent dataType="Bool">false</ignoreParent>
                        <pos dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">1167</X>
                          <Y dataType="Float">407</Y>
                          <Z dataType="Float">0</Z>
                        </pos>
                        <posAbs dataType="Struct" type="Duality.Vector3">
                          <X dataType="Float">1167</X>
                          <Y dataType="Float">407</Y>
                          <Z dataType="Float">0</Z>
                        </posAbs>
                        <scale dataType="Float">1</scale>
                        <scaleAbs dataType="Float">1</scaleAbs>
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="780763848">
                        <active dataType="Bool">true</active>
                        <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                          <A dataType="Byte">0</A>
                          <B dataType="Byte">255</B>
                          <G dataType="Byte">255</G>
                          <R dataType="Byte">255</R>
                        </colorTint>
                        <customMat />
                        <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                        <gameobj dataType="ObjectRef">3607111864</gameobj>
                        <offset dataType="Float">79</offset>
                        <pixelGrid dataType="Bool">false</pixelGrid>
                        <rect dataType="Struct" type="Duality.Rect">
                          <H dataType="Float">40</H>
                          <W dataType="Float">60</W>
                          <X dataType="Float">0</X>
                          <Y dataType="Float">0</Y>
                        </rect>
                        <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                        <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                          <contentPath dataType="String">Data\Camera\button\button.Material.res</contentPath>
                        </sharedMat>
                        <spriteIndex dataType="Int">0</spriteIndex>
                        <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                      </item>
                      <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="3347308404">
                        <active dataType="Bool">true</active>
                        <animDuration dataType="Float">2</animDuration>
                        <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
                        <animTime dataType="Float">0</animTime>
                        <customFrameSequence />
                        <firstFrame dataType="Int">0</firstFrame>
                        <frameCount dataType="Int">2</frameCount>
                        <gameobj dataType="ObjectRef">3607111864</gameobj>
                        <paused dataType="Bool">false</paused>
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.CameraButton" id="2117330591">
                        <active dataType="Bool">true</active>
                        <animator />
                        <gameobj dataType="ObjectRef">3607111864</gameobj>
                        <number dataType="Int">10</number>
                        <renderer />
                        <transform />
                      </item>
                      <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="3202787392">
                        <active dataType="Bool">true</active>
                        <gameobj dataType="ObjectRef">3607111864</gameobj>
                        <render />
                      </item>
                    </_items>
                    <_size dataType="Int">5</_size>
                  </compList>
                  <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="949072800" surrogate="true">
                    <header />
                    <body>
                      <keys dataType="Array" type="System.Object[]" id="2844088584">
                        <item dataType="ObjectRef">3757206646</item>
                        <item dataType="ObjectRef">1240285980</item>
                        <item dataType="ObjectRef">1128967702</item>
                        <item dataType="ObjectRef">1180528928</item>
                        <item dataType="ObjectRef">2905165420</item>
                      </keys>
                      <values dataType="Array" type="System.Object[]" id="2434265054">
                        <item dataType="ObjectRef">3664389082</item>
                        <item dataType="ObjectRef">780763848</item>
                        <item dataType="ObjectRef">3347308404</item>
                        <item dataType="ObjectRef">3202787392</item>
                        <item dataType="ObjectRef">2117330591</item>
                      </values>
                    </body>
                  </compMap>
                  <compTransform dataType="ObjectRef">3664389082</compTransform>
                  <identifier dataType="Struct" type="System.Guid" surrogate="true">
                    <header>
                      <data dataType="Array" type="System.Byte[]" id="1594853108">h9IAEcR3LUCA7kB6XZhetw==</data>
                    </header>
                    <body />
                  </identifier>
                  <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                  <name dataType="String">Cam 7</name>
                  <parent dataType="ObjectRef">2578211885</parent>
                  <prefabLink />
                </item>
              </_items>
              <_size dataType="Int">11</_size>
            </children>
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1699382400">
              <_items dataType="Array" type="Duality.Component[]" id="3026052179" length="0" />
              <_size dataType="Int">0</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1890068475" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="1455563796" length="0" />
                <values dataType="Array" type="System.Object[]" id="2844904246" length="0" />
              </body>
            </compMap>
            <compTransform />
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="125922480">YZHpLUhOQUebVSx7H/E3+Q==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">Buttons</name>
            <parent dataType="ObjectRef">3555090940</parent>
            <prefabLink />
          </item>
        </_items>
        <_size dataType="Int">1</_size>
      </children>
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="95881162">
        <_items dataType="Array" type="Duality.Component[]" id="3797286856">
          <item dataType="Struct" type="Duality.Components.Transform" id="3612368158">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">3555090940</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">850</X>
              <Y dataType="Float">300</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">850</X>
              <Y dataType="Float">300</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="728742924">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">0</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">3555090940</gameobj>
            <offset dataType="Float">80</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">400</H>
              <W dataType="Float">400</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Camera\map.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">0</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="3295287480">
            <active dataType="Bool">true</active>
            <animDuration dataType="Float">2</animDuration>
            <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
            <animTime dataType="Float">0</animTime>
            <customFrameSequence />
            <firstFrame dataType="Int">0</firstFrame>
            <frameCount dataType="Int">2</frameCount>
            <gameobj dataType="ObjectRef">3555090940</gameobj>
            <paused dataType="Bool">false</paused>
          </item>
          <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="3150766468">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">3555090940</gameobj>
            <render />
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="542741410" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="928209568">
            <item dataType="ObjectRef">3757206646</item>
            <item dataType="ObjectRef">1240285980</item>
            <item dataType="ObjectRef">1128967702</item>
            <item dataType="ObjectRef">1180528928</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="359453838">
            <item dataType="ObjectRef">3612368158</item>
            <item dataType="ObjectRef">728742924</item>
            <item dataType="ObjectRef">3295287480</item>
            <item dataType="ObjectRef">3150766468</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3612368158</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1850995388">6QOcCrOPQE68ni4n7n4njA==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">map</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2786225269">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="892008455">
        <_items dataType="Array" type="Duality.Component[]" id="2152759886" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="2843502487">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2786225269</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">253</X>
              <Y dataType="Float">620</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">253</X>
              <Y dataType="Float">620</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="4254844549">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">2786225269</gameobj>
            <offset dataType="Float">50</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">60</H>
              <W dataType="Float">600</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Camera\flip panel.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">-1</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group2" value="4" />
          </item>
          <item dataType="Struct" type="FNaFMP.Office.FlipButton" id="4220880902">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2786225269</gameobj>
            <renderer />
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2807623808" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3727688109">
            <item dataType="ObjectRef">3757206646</item>
            <item dataType="ObjectRef">1240285980</item>
            <item dataType="Type" id="4210793830" value="FNaFMP.Office.FlipButton" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="3555985784">
            <item dataType="ObjectRef">2843502487</item>
            <item dataType="ObjectRef">4254844549</item>
            <item dataType="ObjectRef">4220880902</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2843502487</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3864735175">RPYrAotVckaYNr8j7TVeLg==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">flip panel</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="3573152774">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2572550352">
        <_items dataType="Array" type="Duality.Component[]" id="875948732">
          <item dataType="Struct" type="Duality.Components.Transform" id="3630429992">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">3573152774</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="746804758">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">0</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">3573152774</gameobj>
            <offset dataType="Float">0</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">720</H>
              <W dataType="Float">1280</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Camera\animation\cam_up.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">0</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group3" value="8" />
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="3313349314">
            <active dataType="Bool">true</active>
            <animDuration dataType="Float">0.4</animDuration>
            <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
            <animTime dataType="Float">0</animTime>
            <customFrameSequence />
            <firstFrame dataType="Int">0</firstFrame>
            <frameCount dataType="Int">11</frameCount>
            <gameobj dataType="ObjectRef">3573152774</gameobj>
            <paused dataType="Bool">true</paused>
          </item>
          <item dataType="Struct" type="FNaFMP.Office.CameraAnimator" id="1135260394">
            <active dataType="Bool">true</active>
            <animator />
            <area dataType="Struct" type="Duality.Rect">
              <H dataType="Float">60</H>
              <W dataType="Float">610</W>
              <X dataType="Float">250</X>
              <Y dataType="Float">620</Y>
            </area>
            <down dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Camera\animation\cam_down.Material.res</contentPath>
            </down>
            <down_sound dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
              <contentPath dataType="String">Data\Camera\animation\cam_down.Sound.res</contentPath>
            </down_sound>
            <down_source />
            <gameobj dataType="ObjectRef">3573152774</gameobj>
            <hover dataType="Bool">false</hover>
            <renderer />
            <up dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Camera\animation\cam_up.Material.res</contentPath>
            </up>
            <up_sound dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
              <contentPath dataType="String">Data\Camera\animation\cam_up.Sound.res</contentPath>
            </up_sound>
            <up_source />
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3795083886" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="1185405858">
            <item dataType="ObjectRef">3757206646</item>
            <item dataType="ObjectRef">1240285980</item>
            <item dataType="ObjectRef">1128967702</item>
            <item dataType="Type" id="3347172624" value="FNaFMP.Office.CameraAnimator" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2356413706">
            <item dataType="ObjectRef">3630429992</item>
            <item dataType="ObjectRef">746804758</item>
            <item dataType="ObjectRef">3313349314</item>
            <item dataType="ObjectRef">1135260394</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3630429992</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3691214418">8uEjSdstyEu6zxv+9SfHMw==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Camera Animation</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="1044058778">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1724122308">
        <_items dataType="Array" type="Duality.Component[]" id="446764868">
          <item dataType="Struct" type="Duality.Components.Transform" id="1101335996">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">1044058778</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2512678058">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">0</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">1044058778</gameobj>
            <offset dataType="Float">140</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">720</H>
              <W dataType="Float">1280</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\blip\blip.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">0</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="784255318">
            <active dataType="Bool">true</active>
            <animDuration dataType="Float">0.1</animDuration>
            <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
            <animTime dataType="Float">0</animTime>
            <customFrameSequence />
            <firstFrame dataType="Int">0</firstFrame>
            <frameCount dataType="Int">9</frameCount>
            <gameobj dataType="ObjectRef">1044058778</gameobj>
            <paused dataType="Bool">true</paused>
          </item>
          <item dataType="Struct" type="FNaFMP.Office.BlipAnimator" id="1580661164">
            <active dataType="Bool">true</active>
            <animator />
            <gameobj dataType="ObjectRef">1044058778</gameobj>
            <sound dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
              <contentPath dataType="String">Data\blip\blip.Sound.res</contentPath>
            </sound>
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="748440470" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="1926206286">
            <item dataType="ObjectRef">3757206646</item>
            <item dataType="ObjectRef">1240285980</item>
            <item dataType="ObjectRef">1128967702</item>
            <item dataType="Type" id="1815235280" value="FNaFMP.Office.BlipAnimator" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2192172618">
            <item dataType="ObjectRef">1101335996</item>
            <item dataType="ObjectRef">2512678058</item>
            <item dataType="ObjectRef">784255318</item>
            <item dataType="ObjectRef">1580661164</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1101335996</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1151932158">1RJDRQDp2E+iTmONrAM3PQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">blip</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2885766376">
      <active dataType="Bool">true</active>
      <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="1630662702">
        <_items dataType="Array" type="Duality.GameObject[]" id="758131536" length="4">
          <item dataType="Struct" type="Duality.GameObject" id="623954932">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2943829692">
              <_items dataType="Array" type="Duality.Component[]" id="1453490756">
                <item dataType="Struct" type="Duality.Components.Transform" id="681232150">
                  <active dataType="Bool">true</active>
                  <angle dataType="Float">0</angle>
                  <angleAbs dataType="Float">0</angleAbs>
                  <gameobj dataType="ObjectRef">623954932</gameobj>
                  <ignoreParent dataType="Bool">true</ignoreParent>
                  <pos dataType="Struct" type="Duality.Vector3">
                    <X dataType="Float">6</X>
                    <Y dataType="Float">263</Y>
                    <Z dataType="Float">0</Z>
                  </pos>
                  <posAbs dataType="Struct" type="Duality.Vector3">
                    <X dataType="Float">6</X>
                    <Y dataType="Float">263</Y>
                    <Z dataType="Float">0</Z>
                  </posAbs>
                  <scale dataType="Float">1</scale>
                  <scaleAbs dataType="Float">1</scaleAbs>
                </item>
                <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2092574212">
                  <active dataType="Bool">true</active>
                  <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                    <A dataType="Byte">255</A>
                    <B dataType="Byte">255</B>
                    <G dataType="Byte">255</G>
                    <R dataType="Byte">255</R>
                  </colorTint>
                  <customMat />
                  <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                  <gameobj dataType="ObjectRef">623954932</gameobj>
                  <offset dataType="Float">0</offset>
                  <pixelGrid dataType="Bool">false</pixelGrid>
                  <rect dataType="Struct" type="Duality.Rect">
                    <H dataType="Float">247</H>
                    <W dataType="Float">92</W>
                    <X dataType="Float">0</X>
                    <Y dataType="Float">0</Y>
                  </rect>
                  <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                  <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                    <contentPath dataType="String">Data\Doors\Left\Panel\left-oN.Material.res</contentPath>
                  </sharedMat>
                  <spriteIndex dataType="Int">-1</spriteIndex>
                  <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
                </item>
                <item dataType="Struct" type="FNaFMP.Office.OfficeController" id="959204500">
                  <active dataType="Bool">true</active>
                  <control dataType="Struct" type="FNaFMP.Office.OfficeControllerValue" id="2364194196">
                    <closed_light dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                      <contentPath dataType="String">Data\Doors\Left\Panel\left-cY.Material.res</contentPath>
                    </closed_light>
                    <closed_nolight dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                      <contentPath dataType="String">Data\Doors\Left\Panel\left-cN.Material.res</contentPath>
                    </closed_nolight>
                    <direction dataType="Enum" type="FNaFMP.Office.DoorDirection" name="Left" value="1" />
                    <door dataType="Struct" type="Duality.Rect">
                      <H dataType="Float">120</H>
                      <W dataType="Float">62</W>
                      <X dataType="Float">25</X>
                      <Y dataType="Float">252</Y>
                    </door>
                    <killed dataType="Bool">false</killed>
                    <killedSound dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]" />
                    <light dataType="Struct" type="Duality.Rect">
                      <H dataType="Float">120</H>
                      <W dataType="Float">62</W>
                      <X dataType="Float">26</X>
                      <Y dataType="Float">393</Y>
                    </light>
                    <lightSound dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
                      <contentPath dataType="String">Data\Doors\light.Sound.res</contentPath>
                    </lightSound>
                    <open_light dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                      <contentPath dataType="String">Data\Doors\Left\Panel\left-oY.Material.res</contentPath>
                    </open_light>
                    <open_nolight dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                      <contentPath dataType="String">Data\Doors\Left\Panel\left-oN.Material.res</contentPath>
                    </open_nolight>
                  </control>
                  <gameobj dataType="ObjectRef">623954932</gameobj>
                  <random dataType="Struct" type="System.Random" id="2827153462">
                    <inext dataType="Int">0</inext>
                    <inextp dataType="Int">21</inextp>
                    <SeedArray dataType="Array" type="System.Int32[]" id="3319982142">0, 1997300952, 2106566580, 209244923, 1378759132, 1339194957, 147773207, 1346011034, 1037875007, 416011793, 1857175024, 1022297027, 365866202, 11028385, 204882631, 1114748273, 2734503, 771177825, 25200602, 408553370, 913507528, 1958705737, 196339461, 1761591373, 1932650762, 1849279461, 662850010, 1520298576, 2095192997, 1400691484, 1230672668, 1076341719, 2041718212, 1145822183, 425422702, 1219511464, 1076488565, 1035226962, 253181395, 1963109962, 543200486, 1953043242, 1971701055, 1319624869, 348898054, 1621571622, 1178950099, 387862157, 1191547448, 830295259, 1246852033, 33660062, 1763897576, 1659947838, 103141762, 1286965610</SeedArray>
                  </random>
                  <renderer />
                  <source />
                  <started dataType="Bool">false</started>
                </item>
                <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="219630460">
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">623954932</gameobj>
                  <render />
                </item>
              </_items>
              <_size dataType="Int">4</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="332759702" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="1939877782">
                  <item dataType="ObjectRef">3757206646</item>
                  <item dataType="ObjectRef">1240285980</item>
                  <item dataType="ObjectRef">1180528928</item>
                  <item dataType="Type" id="3822350368" value="FNaFMP.Office.OfficeController" />
                </keys>
                <values dataType="Array" type="System.Object[]" id="1431506650">
                  <item dataType="ObjectRef">681232150</item>
                  <item dataType="ObjectRef">2092574212</item>
                  <item dataType="ObjectRef">219630460</item>
                  <item dataType="ObjectRef">959204500</item>
                </values>
              </body>
            </compMap>
            <compTransform dataType="ObjectRef">681232150</compTransform>
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="1574282294">B2uJyPRW3kmx6HQtwy3bPw==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">Panel</name>
            <parent dataType="ObjectRef">2885766376</parent>
            <prefabLink />
          </item>
        </_items>
        <_size dataType="Int">1</_size>
      </children>
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="466621642">
        <_items dataType="Array" type="Duality.Component[]" id="4067062956" length="8">
          <item dataType="Struct" type="Duality.Components.Transform" id="2943043594">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2885766376</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">68</X>
              <Y dataType="Float">-1</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">68</X>
              <Y dataType="Float">-1</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="59418360">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">2885766376</gameobj>
            <offset dataType="Float">150</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">720</H>
              <W dataType="Float">223</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Doors\Left\left-open.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">0</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="2625962916">
            <active dataType="Bool">true</active>
            <animDuration dataType="Float">0.5</animDuration>
            <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
            <animTime dataType="Float">0</animTime>
            <customFrameSequence />
            <firstFrame dataType="Int">0</firstFrame>
            <frameCount dataType="Int">1</frameCount>
            <gameobj dataType="ObjectRef">2885766376</gameobj>
            <paused dataType="Bool">true</paused>
          </item>
          <item dataType="Struct" type="FNaFMP.Office.DoorAnimator" id="2832897389">
            <active dataType="Bool">true</active>
            <anim dataType="Bool">false</anim>
            <animator />
            <close dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Doors\Left\left-closed.Material.res</contentPath>
            </close>
            <closing dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Doors\Left\left-closing.Material.res</contentPath>
            </closing>
            <direction dataType="Enum" type="FNaFMP.Office.DoorDirection" name="Left" value="1" />
            <gameobj dataType="ObjectRef">2885766376</gameobj>
            <open dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Doors\Left\left-open.Material.res</contentPath>
            </open>
            <opening dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Doors\Left\left-opening.Material.res</contentPath>
            </opening>
            <renderer />
            <sound dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
              <contentPath dataType="String">Data\Doors\door.Sound.res</contentPath>
            </sound>
            <state dataType="Int">0</state>
            <transform />
          </item>
          <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="2481441904">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2885766376</gameobj>
            <render />
          </item>
        </_items>
        <_size dataType="Int">5</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3321444766" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="494125600">
            <item dataType="ObjectRef">3757206646</item>
            <item dataType="ObjectRef">1240285980</item>
            <item dataType="ObjectRef">1128967702</item>
            <item dataType="ObjectRef">1180528928</item>
            <item dataType="Type" id="3448165340" value="FNaFMP.Office.DoorAnimator" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="3779320718">
            <item dataType="ObjectRef">2943043594</item>
            <item dataType="ObjectRef">59418360</item>
            <item dataType="ObjectRef">2625962916</item>
            <item dataType="ObjectRef">2481441904</item>
            <item dataType="ObjectRef">2832897389</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2943043594</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1178218812">Dwoh+QdLq06jVFk6Wr3j8g==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Left Door</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2127599329">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1025315363">
        <_items dataType="Array" type="Duality.Component[]" id="4214265958" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="2184876547">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2127599329</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">463</X>
              <Y dataType="Float">75</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">463</X>
              <Y dataType="Float">75</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3596218609">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">0</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">2127599329</gameobj>
            <offset dataType="Float">0</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">54</H>
              <W dataType="Float">371</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Camera\cam_disabled.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">-1</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group2" value="4" />
          </item>
          <item dataType="Struct" type="FNaFMP.Office.DisabledCamera" id="2254648712">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2127599329</gameobj>
            <render />
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="4239667320" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2098520905">
            <item dataType="ObjectRef">3757206646</item>
            <item dataType="ObjectRef">1240285980</item>
            <item dataType="Type" id="34757518" value="FNaFMP.Office.DisabledCamera" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="1447840576">
            <item dataType="ObjectRef">2184876547</item>
            <item dataType="ObjectRef">3596218609</item>
            <item dataType="ObjectRef">2254648712</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2184876547</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3741360491">XYwOlRYiJ02B6oeKU/9ilQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">cam_disabled</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="3812094120">
      <active dataType="Bool">true</active>
      <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="1070798958">
        <_items dataType="Array" type="Duality.GameObject[]" id="1383773776" length="4">
          <item dataType="Struct" type="Duality.GameObject" id="3403385727">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3873837435">
              <_items dataType="Array" type="Duality.Component[]" id="463649622">
                <item dataType="Struct" type="Duality.Components.Transform" id="3460662945">
                  <active dataType="Bool">true</active>
                  <angle dataType="Float">0</angle>
                  <angleAbs dataType="Float">0</angleAbs>
                  <gameobj dataType="ObjectRef">3403385727</gameobj>
                  <ignoreParent dataType="Bool">true</ignoreParent>
                  <pos dataType="Struct" type="Duality.Vector3">
                    <X dataType="Float">1497</X>
                    <Y dataType="Float">263</Y>
                    <Z dataType="Float">0</Z>
                  </pos>
                  <posAbs dataType="Struct" type="Duality.Vector3">
                    <X dataType="Float">1497</X>
                    <Y dataType="Float">263</Y>
                    <Z dataType="Float">0</Z>
                  </posAbs>
                  <scale dataType="Float">1</scale>
                  <scaleAbs dataType="Float">1</scaleAbs>
                </item>
                <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="577037711">
                  <active dataType="Bool">true</active>
                  <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                    <A dataType="Byte">255</A>
                    <B dataType="Byte">255</B>
                    <G dataType="Byte">255</G>
                    <R dataType="Byte">255</R>
                  </colorTint>
                  <customMat />
                  <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                  <gameobj dataType="ObjectRef">3403385727</gameobj>
                  <offset dataType="Float">0</offset>
                  <pixelGrid dataType="Bool">false</pixelGrid>
                  <rect dataType="Struct" type="Duality.Rect">
                    <H dataType="Float">247</H>
                    <W dataType="Float">92</W>
                    <X dataType="Float">0</X>
                    <Y dataType="Float">0</Y>
                  </rect>
                  <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                  <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                    <contentPath dataType="String">Data\Doors\Right\Panel\right-oN.Material.res</contentPath>
                  </sharedMat>
                  <spriteIndex dataType="Int">-1</spriteIndex>
                  <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
                </item>
                <item dataType="Struct" type="FNaFMP.Office.OfficeController" id="3738635295">
                  <active dataType="Bool">true</active>
                  <control dataType="Struct" type="FNaFMP.Office.OfficeControllerValue" id="3853791423">
                    <closed_light dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                      <contentPath dataType="String">Data\Doors\Right\Panel\right-cY.Material.res</contentPath>
                    </closed_light>
                    <closed_nolight dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                      <contentPath dataType="String">Data\Doors\Right\Panel\right-cN.Material.res</contentPath>
                    </closed_nolight>
                    <direction dataType="Enum" type="FNaFMP.Office.DoorDirection" name="Right" value="2" />
                    <door dataType="Struct" type="Duality.Rect">
                      <H dataType="Float">120</H>
                      <W dataType="Float">62</W>
                      <X dataType="Float">1519</X>
                      <Y dataType="Float">268</Y>
                    </door>
                    <killed dataType="Bool">false</killed>
                    <killedSound dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]" />
                    <light dataType="Struct" type="Duality.Rect">
                      <H dataType="Float">120</H>
                      <W dataType="Float">62</W>
                      <X dataType="Float">1520</X>
                      <Y dataType="Float">398</Y>
                    </light>
                    <lightSound dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
                      <contentPath dataType="String">Data\Doors\light.Sound.res</contentPath>
                    </lightSound>
                    <open_light dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                      <contentPath dataType="String">Data\Doors\Right\Panel\right-oY.Material.res</contentPath>
                    </open_light>
                    <open_nolight dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                      <contentPath dataType="String">Data\Doors\Right\Panel\right-oN.Material.res</contentPath>
                    </open_nolight>
                  </control>
                  <gameobj dataType="ObjectRef">3403385727</gameobj>
                  <random dataType="Struct" type="System.Random" id="4270342624">
                    <inext dataType="Int">0</inext>
                    <inextp dataType="Int">21</inextp>
                    <SeedArray dataType="Array" type="System.Int32[]" id="3393095541">0, 1804333697, 1574772088, 979189224, 1137385959, 1062103584, 1137049447, 1068833102, 1444058137, 1946686768, 1234847232, 1320860139, 827406209, 1181240601, 300478969, 912182049, 1445838914, 1536764271, 832244490, 1783054171, 1854357001, 722381299, 1285528986, 1146500787, 610509999, 1443864644, 1426365320, 1137574211, 1945186645, 880094867, 1845219508, 1203738405, 1711165899, 721581206, 1897935589, 1024704393, 791655130, 265086281, 1910666329, 1024985805, 798443296, 1539308805, 1419186744, 1815678965, 526557426, 1387650272, 1591288998, 680149204, 254417028, 94759651, 886615780, 849913867, 1709717451, 196272889, 1359366760, 859283020</SeedArray>
                  </random>
                  <renderer />
                  <source />
                  <started dataType="Bool">false</started>
                </item>
                <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="2999061255">
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">3403385727</gameobj>
                  <render />
                </item>
              </_items>
              <_size dataType="Int">4</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3960023208" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="2159155857">
                  <item dataType="ObjectRef">3757206646</item>
                  <item dataType="ObjectRef">1240285980</item>
                  <item dataType="ObjectRef">3822350368</item>
                  <item dataType="ObjectRef">1180528928</item>
                </keys>
                <values dataType="Array" type="System.Object[]" id="694356640">
                  <item dataType="ObjectRef">3460662945</item>
                  <item dataType="ObjectRef">577037711</item>
                  <item dataType="ObjectRef">3738635295</item>
                  <item dataType="ObjectRef">2999061255</item>
                </values>
              </body>
            </compMap>
            <compTransform dataType="ObjectRef">3460662945</compTransform>
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="3151569667">Fc+tF19vNUqyeJQKBdLzIA==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">Panel</name>
            <parent dataType="ObjectRef">3812094120</parent>
            <prefabLink />
          </item>
        </_items>
        <_size dataType="Int">1</_size>
      </children>
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="918736842">
        <_items dataType="Array" type="Duality.Component[]" id="3387911660" length="8">
          <item dataType="Struct" type="Duality.Components.Transform" id="3869371338">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">3812094120</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">1272</X>
              <Y dataType="Float">-1</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">1272</X>
              <Y dataType="Float">-1</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="985746104">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">3812094120</gameobj>
            <offset dataType="Float">0</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">720</H>
              <W dataType="Float">248</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Doors\Right\right-open.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">0</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="3552290660">
            <active dataType="Bool">true</active>
            <animDuration dataType="Float">0.5</animDuration>
            <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
            <animTime dataType="Float">0</animTime>
            <customFrameSequence />
            <firstFrame dataType="Int">0</firstFrame>
            <frameCount dataType="Int">1</frameCount>
            <gameobj dataType="ObjectRef">3812094120</gameobj>
            <paused dataType="Bool">true</paused>
          </item>
          <item dataType="Struct" type="FNaFMP.Office.DoorAnimator" id="3759225133">
            <active dataType="Bool">true</active>
            <anim dataType="Bool">false</anim>
            <animator />
            <close dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Doors\Right\right-closed.Material.res</contentPath>
            </close>
            <closing dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Doors\Right\right-closing.Material.res</contentPath>
            </closing>
            <direction dataType="Enum" type="FNaFMP.Office.DoorDirection" name="Right" value="2" />
            <gameobj dataType="ObjectRef">3812094120</gameobj>
            <open dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Doors\Right\right-open.Material.res</contentPath>
            </open>
            <opening dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Doors\Right\right-opening.Material.res</contentPath>
            </opening>
            <renderer />
            <sound dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
              <contentPath dataType="String">Data\Doors\door.Sound.res</contentPath>
            </sound>
            <state dataType="Int">0</state>
            <transform />
          </item>
          <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="3407769648">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">3812094120</gameobj>
            <render />
          </item>
        </_items>
        <_size dataType="Int">5</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3007402078" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3996850848">
            <item dataType="ObjectRef">3757206646</item>
            <item dataType="ObjectRef">1240285980</item>
            <item dataType="ObjectRef">1128967702</item>
            <item dataType="ObjectRef">3448165340</item>
            <item dataType="ObjectRef">1180528928</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="3979433102">
            <item dataType="ObjectRef">3869371338</item>
            <item dataType="ObjectRef">985746104</item>
            <item dataType="ObjectRef">3552290660</item>
            <item dataType="ObjectRef">3759225133</item>
            <item dataType="ObjectRef">3407769648</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3869371338</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="4262146748">MbqyqZbFPESHTMk+sK3keA==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Right Door</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2795150931">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3062355809">
        <_items dataType="Array" type="Duality.Component[]" id="1252067182">
          <item dataType="Struct" type="Duality.Components.Transform" id="2852428149">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2795150931</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">830</X>
              <Y dataType="Float">288</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">830</X>
              <Y dataType="Float">288</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="4263770211">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">0</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">2795150931</gameobj>
            <offset dataType="Float">0</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">26</H>
              <W dataType="Float">217</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Camera\Location Text\stage.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">-1</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
          </item>
          <item dataType="Struct" type="FNaFMP.Office.LocationRenderer" id="1432269467">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2795150931</gameobj>
            <list dataType="Struct" type="System.Collections.Generic.List`1[[Duality.ContentRef`1[[Duality.Resources.Material]]]]" id="163543227">
              <_items dataType="Array" type="Duality.ContentRef`1[[Duality.Resources.Material]][]" id="132752598" length="16">
                <item dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                  <contentPath dataType="String">Data\Camera\Location Text\stage.Material.res</contentPath>
                </item>
                <item dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                  <contentPath dataType="String">Data\Camera\Location Text\dining.Material.res</contentPath>
                </item>
                <item dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                  <contentPath dataType="String">Data\Camera\Location Text\cove.Material.res</contentPath>
                </item>
                <item dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                  <contentPath dataType="String">Data\Camera\Location Text\west_hall.Material.res</contentPath>
                </item>
                <item dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                  <contentPath dataType="String">Data\Camera\Location Text\west_hall_corner.Material.res</contentPath>
                </item>
                <item dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                  <contentPath dataType="String">Data\Camera\Location Text\closet.Material.res</contentPath>
                </item>
                <item dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                  <contentPath dataType="String">Data\Camera\Location Text\east_hall.Material.res</contentPath>
                </item>
                <item dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                  <contentPath dataType="String">Data\Camera\Location Text\east_hall_corner.Material.res</contentPath>
                </item>
                <item dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                  <contentPath dataType="String">Data\Camera\Location Text\backstage.Material.res</contentPath>
                </item>
                <item dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                  <contentPath dataType="String">Data\Camera\Location Text\kitchen.Material.res</contentPath>
                </item>
                <item dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                  <contentPath dataType="String">Data\Camera\Location Text\restrooms.Material.res</contentPath>
                </item>
              </_items>
              <_size dataType="Int">11</_size>
            </list>
            <renderer />
            <transform />
          </item>
          <item dataType="Struct" type="FNaFMP.Office.VisibilityController" id="2390826459">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2795150931</gameobj>
            <render />
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1161550368" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="1757745387">
            <item dataType="ObjectRef">3757206646</item>
            <item dataType="ObjectRef">1240285980</item>
            <item dataType="Type" id="2223736950" value="FNaFMP.Office.LocationRenderer" />
            <item dataType="ObjectRef">1180528928</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="3776551624">
            <item dataType="ObjectRef">2852428149</item>
            <item dataType="ObjectRef">4263770211</item>
            <item dataType="ObjectRef">1432269467</item>
            <item dataType="ObjectRef">2390826459</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2852428149</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3238380513">8fZPxnqxKEOykIvMTIoxsQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Location Text</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="ObjectRef">2578211885</item>
    <item dataType="ObjectRef">623954932</item>
    <item dataType="ObjectRef">3403385727</item>
    <item dataType="ObjectRef">4075703128</item>
    <item dataType="ObjectRef">2628574494</item>
    <item dataType="ObjectRef">3270008394</item>
    <item dataType="ObjectRef">1912945850</item>
    <item dataType="ObjectRef">2139926961</item>
    <item dataType="ObjectRef">805991366</item>
    <item dataType="ObjectRef">2645946997</item>
    <item dataType="ObjectRef">3026069331</item>
    <item dataType="ObjectRef">1073131587</item>
    <item dataType="ObjectRef">2480585226</item>
    <item dataType="ObjectRef">3607111864</item>
    <item dataType="ObjectRef">2586317313</item>
    <item dataType="ObjectRef">525618244</item>
    <item dataType="ObjectRef">1706951847</item>
    <item dataType="ObjectRef">2183099095</item>
    <item dataType="ObjectRef">1605021198</item>
    <item dataType="ObjectRef">2085367654</item>
    <item dataType="ObjectRef">1377852436</item>
    <item dataType="ObjectRef">3697224140</item>
    <item dataType="ObjectRef">3657089679</item>
    <item dataType="ObjectRef">4239293993</item>
    <item dataType="ObjectRef">4139811160</item>
  </serializeObj>
  <visibilityStrategy dataType="Struct" type="Duality.Components.DefaultRendererVisibilityStrategy" id="2035693768" />
</root>
<!-- XmlFormatterBase Document Separator -->
