using Piglet.Newtonsoft.Json;

namespace Piglet.GLTF.Schema
{
	/// <summary>
	/// A camera's projection.  A node can reference a camera to apply a transform
	/// to place the camera in the scene
	/// </summary>
	public class Camera : GLTFChildOfRootProperty
	{
		/// <summary>
		/// An orthographic camera containing properties to create an orthographic
		/// projection matrix.
		/// </summary>
		public CameraOrthographic Orthographic;

		/// <summary>
		/// A perspective camera containing properties to create a perspective
		/// projection matrix.
		/// </summary>
		public CameraPerspective Perspective;

		/// <summary>
		/// Specifies if the camera uses a perspective or orthographic projection.
		/// Based on this, either the camera's `perspective` or `orthographic` property
		/// will be defined.
		/// </summary>
		public CameraType Type;

		public static Camera Deserialize(GLTFRoot root, JsonReader reader)
		{
			var camera = new Camera();

			while (reader.Read() && reader.TokenType == JsonToken.PropertyName)
			{
				var curProp = reader.Value.ToString();

				switch (curProp)
				{
					case "orthographic":
						camera.Orthographic = CameraOrthographic.Deserialize(root, reader);
						camera.Type = CameraType.orthographic;
						break;
					case "perspective":
						camera.Perspective = CameraPerspective.Deserialize(root, reader);
						camera.Type = CameraType.perspective;
						break;
					default:
						camera.DefaultPropertyDeserializer(root, reader);
						break;
				}
			}

			return camera;
		}

		public override void Serialize(JsonWriter writer)
		{
			writer.WriteStartObject();

			if (Orthographic != null)
			{
				writer.WritePropertyName("orthographic");
				Orthographic.Serialize(writer);
			}

			if (Perspective != null)
			{
				writer.WritePropertyName("perspective");
				Perspective.Serialize(writer);
			}

			writer.WritePropertyName("type");
			writer.WriteValue(Type.ToString());

			base.Serialize(writer);

			writer.WriteEndObject();
		}
	}

	public enum CameraType
	{
		perspective,
		orthographic
	}
}
