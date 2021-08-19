<root dataType="Struct" type="Duality.Resources.Scene" id="129723834">
  <assetInfo />
  <globalGravity dataType="Struct" type="Duality.Vector2">
    <X dataType="Float">0</X>
    <Y dataType="Float">33</Y>
  </globalGravity>
  <serializeObj dataType="Array" type="Duality.GameObject[]" id="427169525">
    <item dataType="Struct" type="Duality.GameObject" id="2083604718">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="4136940984">
        <_items dataType="Array" type="Duality.Component[]" id="3058791532" length="8">
          <item dataType="Struct" type="Duality.Components.Transform" id="2140881936">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2083604718</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Camera" id="3629991195">
            <active dataType="Bool">true</active>
            <clearColor dataType="Struct" type="Duality.Drawing.ColorRgba" />
            <farZ dataType="Float">10000</farZ>
            <focusDist dataType="Float">500</focusDist>
            <gameobj dataType="ObjectRef">2083604718</gameobj>
            <nearZ dataType="Float">50</nearZ>
            <priority dataType="Int">0</priority>
            <projection dataType="Enum" type="Duality.Drawing.ProjectionMode" name="Screen" value="2" />
            <renderSetup dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderSetup]]" />
            <renderTarget dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderTarget]]" />
            <shaderParameters dataType="Struct" type="Duality.Drawing.ShaderParameterCollection" id="2081191831" custom="true">
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
          <item dataType="Struct" type="Duality.Components.VelocityTracker" id="4154739185">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2083604718</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.SoundEmitter" id="9449305">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2083604718</gameobj>
            <sources dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.SoundEmitter+Source]]" id="1147875589">
              <_items dataType="Array" type="Duality.Components.SoundEmitter+Source[]" id="1505484374" length="4">
                <item dataType="Struct" type="Duality.Components.SoundEmitter+Source" id="1859751968">
                  <looped dataType="Bool">false</looped>
                  <lowpass dataType="Float">1</lowpass>
                  <offset dataType="Struct" type="Duality.Vector3" />
                  <paused dataType="Bool">false</paused>
                  <pitch dataType="Float">1</pitch>
                  <sound dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
                    <contentPath dataType="String">Data\Jumpscare\XSCREAM.Sound.res</contentPath>
                  </sound>
                  <volume dataType="Float">1</volume>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </sources>
          </item>
          <item dataType="Struct" type="Duality.Components.SoundListener" id="4116257245">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2083604718</gameobj>
          </item>
          <item dataType="Struct" type="FNaFMP.Utility.SoundManager" id="3580784614">
            <active dataType="Bool">true</active>
            <emitter dataType="ObjectRef">9449305</emitter>
            <gameobj dataType="ObjectRef">2083604718</gameobj>
            <list dataType="ObjectRef">1147875589</list>
            <nonloop dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.SoundEmitter+Source]]" id="70614270">
              <_items dataType="Array" type="Duality.Components.SoundEmitter+Source[]" id="751578512" length="0" />
              <_size dataType="Int">0</_size>
            </nonloop>
            <transform dataType="ObjectRef">2140881936</transform>
          </item>
        </_items>
        <_size dataType="Int">6</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1404387550" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="187751930">
            <item dataType="Type" id="4103058816" value="Duality.Components.Transform" />
            <item dataType="Type" id="1799592142" value="Duality.Components.Camera" />
            <item dataType="Type" id="2438742812" value="Duality.Components.VelocityTracker" />
            <item dataType="Type" id="1665874386" value="Duality.Components.SoundEmitter" />
            <item dataType="Type" id="720272696" value="Duality.Components.SoundListener" />
            <item dataType="Type" id="1259806502" value="FNaFMP.Utility.SoundManager" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="1585678650">
            <item dataType="ObjectRef">2140881936</item>
            <item dataType="ObjectRef">3629991195</item>
            <item dataType="ObjectRef">4154739185</item>
            <item dataType="ObjectRef">9449305</item>
            <item dataType="ObjectRef">4116257245</item>
            <item dataType="ObjectRef">3580784614</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2140881936</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="4070013818">X3dDjlfizkCnPfw/Pk3rLw==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Camera</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="3824760541">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="929517295">
        <_items dataType="Array" type="Duality.Component[]" id="3780370158">
          <item dataType="Struct" type="Duality.Components.Transform" id="3882037759">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">3824760541</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="998412525">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">3824760541</gameobj>
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
              <contentPath dataType="String">Data\Jumpscare\jump-freddy-nopower.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">0</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="3564957081">
            <active dataType="Bool">true</active>
            <animDuration dataType="Float">0.5</animDuration>
            <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
            <animTime dataType="Float">0</animTime>
            <customFrameSequence />
            <firstFrame dataType="Int">0</firstFrame>
            <frameCount dataType="Int">21</frameCount>
            <gameobj dataType="ObjectRef">3824760541</gameobj>
            <paused dataType="Bool">false</paused>
          </item>
          <item dataType="Struct" type="FNaFMP.Menu.JumpscareFreddy" id="3455181212">
            <_x003C_DiedScreen_x003E_k__BackingField dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Scene]]">
              <contentPath dataType="String">Data\Scenes\Died.Scene.res</contentPath>
            </_x003C_DiedScreen_x003E_k__BackingField>
            <_x003C_KillSound_x003E_k__BackingField dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
              <contentPath dataType="String">Data\Jumpscare\XSCREAM.Sound.res</contentPath>
            </_x003C_KillSound_x003E_k__BackingField>
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">3824760541</gameobj>
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3552337824" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="751804229">
            <item dataType="ObjectRef">4103058816</item>
            <item dataType="Type" id="835142870" value="Duality.Components.Renderers.SpriteRenderer" />
            <item dataType="Type" id="2931905498" value="Duality.Components.Renderers.SpriteAnimator" />
            <item dataType="Type" id="1526652406" value="FNaFMP.Menu.JumpscareFreddy" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="1441589288">
            <item dataType="ObjectRef">3882037759</item>
            <item dataType="ObjectRef">998412525</item>
            <item dataType="ObjectRef">3564957081</item>
            <item dataType="ObjectRef">3455181212</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3882037759</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="2532854479">ofwsc0VGcUmLreGpKeeh5Q==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">jump-freddy-nopower</name>
      <parent />
      <prefabLink />
    </item>
  </serializeObj>
  <visibilityStrategy dataType="Struct" type="Duality.Components.DefaultRendererVisibilityStrategy" id="2035693768" />
</root>
<!-- XmlFormatterBase Document Separator -->
