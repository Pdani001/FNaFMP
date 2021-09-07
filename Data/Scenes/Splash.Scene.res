<root dataType="Struct" type="Duality.Resources.Scene" id="129723834">
  <assetInfo />
  <globalGravity dataType="Struct" type="Duality.Vector2">
    <X dataType="Float">0</X>
    <Y dataType="Float">33</Y>
  </globalGravity>
  <serializeObj dataType="Array" type="Duality.GameObject[]" id="427169525">
    <item dataType="Struct" type="Duality.GameObject" id="45223425">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="998175235">
        <_items dataType="Array" type="Duality.Component[]" id="2668994854" length="8">
          <item dataType="Struct" type="Duality.Components.Transform" id="102500643">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">45223425</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">640</X>
              <Y dataType="Float">360</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">640</X>
              <Y dataType="Float">360</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="1513842705">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">45223425</gameobj>
            <offset dataType="Float">0</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect" />
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]" />
            <spriteIndex dataType="Int">0</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="All" value="4294967295" />
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="4080387261">
            <active dataType="Bool">true</active>
            <animDuration dataType="Float">2</animDuration>
            <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
            <animTime dataType="Float">0</animTime>
            <customFrameSequence />
            <firstFrame dataType="Int">0</firstFrame>
            <frameCount dataType="Int">1</frameCount>
            <gameobj dataType="ObjectRef">45223425</gameobj>
            <paused dataType="Bool">false</paused>
          </item>
          <item dataType="Struct" type="FNaFMP.Startup.Splash" id="2751908383">
            <active dataType="Bool">true</active>
            <count dataType="Int">0</count>
            <forward dataType="Bool">true</forward>
            <gameobj dataType="ObjectRef">45223425</gameobj>
            <isKeyDown dataType="Bool">false</isKeyDown>
            <renderers dataType="Struct" type="System.Collections.Generic.List`1[[Duality.ContentRef`1[[Duality.Resources.Material]]]]" id="4086624735">
              <_items dataType="Array" type="Duality.ContentRef`1[[Duality.Resources.Material]][]" id="2877903470" length="4">
                <item dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                  <contentPath dataType="String">Data\fm-loading.Material.res</contentPath>
                </item>
                <item dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                  <contentPath dataType="String">Default:Material:DualityLogoBig</contentPath>
                </item>
              </_items>
              <_size dataType="Int">2</_size>
            </renderers>
            <scene dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Scene]]">
              <contentPath dataType="String">Data\Scenes\LoadTest.Scene.res</contentPath>
            </scene>
            <time dataType="Int">0</time>
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="632670136" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="1908540777">
            <item dataType="Type" id="3691193614" value="Duality.Components.Transform" />
            <item dataType="Type" id="3340566858" value="Duality.Components.Renderers.SpriteRenderer" />
            <item dataType="Type" id="514452030" value="Duality.Components.Renderers.SpriteAnimator" />
            <item dataType="Type" id="3519836122" value="FNaFMP.Startup.Splash" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2180795072">
            <item dataType="ObjectRef">102500643</item>
            <item dataType="ObjectRef">1513842705</item>
            <item dataType="ObjectRef">4080387261</item>
            <item dataType="ObjectRef">2751908383</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">102500643</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="68937163">goXPyFMyskiRUSZGzMbLSQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">SpriteRenderer</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="394719030">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2106778144">
        <_items dataType="Array" type="Duality.Component[]" id="3376780252" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="451996248">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">394719030</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Camera" id="1941105507">
            <active dataType="Bool">true</active>
            <clearColor dataType="Struct" type="Duality.Drawing.ColorRgba" />
            <farZ dataType="Float">10000</farZ>
            <focusDist dataType="Float">500</focusDist>
            <gameobj dataType="ObjectRef">394719030</gameobj>
            <nearZ dataType="Float">50</nearZ>
            <priority dataType="Int">0</priority>
            <projection dataType="Enum" type="Duality.Drawing.ProjectionMode" name="Perspective" value="1" />
            <renderSetup dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderSetup]]">
              <contentPath dataType="String">Default:RenderSetup:Default</contentPath>
            </renderSetup>
            <renderTarget dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderTarget]]" />
            <shaderParameters dataType="Struct" type="Duality.Drawing.ShaderParameterCollection" id="1675551631" custom="true">
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
        </_items>
        <_size dataType="Int">2</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="4191001486" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2866988786">
            <item dataType="ObjectRef">3691193614</item>
            <item dataType="Type" id="354678224" value="Duality.Components.Camera" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="862615882">
            <item dataType="ObjectRef">451996248</item>
            <item dataType="ObjectRef">1941105507</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">451996248</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="4201001410">V9W4sbSFpkOvOlAIyFXrog==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Camera</name>
      <parent />
      <prefabLink />
    </item>
  </serializeObj>
  <visibilityStrategy dataType="Struct" type="Duality.Components.DefaultRendererVisibilityStrategy" id="2035693768" />
</root>
<!-- XmlFormatterBase Document Separator -->
