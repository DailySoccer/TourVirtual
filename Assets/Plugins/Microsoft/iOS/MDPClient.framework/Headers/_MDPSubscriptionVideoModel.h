//
//  _MDPSubscriptionVideoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPSubscriptionVideoModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPSubscriptionVideoModelAttributes {
	__unsafe_unretained NSString *areaDepartment;
	__unsafe_unretained NSString *camera;
	__unsafe_unretained NSString *descriptionSubscriptionVideo;
	__unsafe_unretained NSString *eventDateTime;
	__unsafe_unretained NSString *expurgateDate;
	__unsafe_unretained NSString *idSubscriptionVideo;
	__unsafe_unretained NSString *language;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *mainActors;
	__unsafe_unretained NSString *place;
	__unsafe_unretained NSString *recordingDate;
	__unsafe_unretained NSString *section;
	__unsafe_unretained NSString *source;
	__unsafe_unretained NSString *subscriptionId;
	__unsafe_unretained NSString *thumbnailUrl;
	__unsafe_unretained NSString *title;
	__unsafe_unretained NSString *uirlHDS;
	__unsafe_unretained NSString *url;
	__unsafe_unretained NSString *urlDash;
	__unsafe_unretained NSString *urlHLS;
	__unsafe_unretained NSString *urlProgressive;
	__unsafe_unretained NSString *urlSmoothStreaming;
	__unsafe_unretained NSString *videoLength;
	__unsafe_unretained NSString *videoTypes;
} MDPSubscriptionVideoModelAttributes;

@interface _MDPSubscriptionVideoModel : NSManagedObject

@property (nonatomic, strong) NSString* areaDepartment;

//- (BOOL)validateAreaDepartment:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* camera;

//- (BOOL)validateCamera:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* descriptionSubscriptionVideo;

//- (BOOL)validateDescriptionSubscriptionVideo:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* eventDateTime;

//- (BOOL)validateEventDateTime:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* expurgateDate;

//- (BOOL)validateExpurgateDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSubscriptionVideo;

//- (BOOL)validateIdSubscriptionVideo:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* language;

//- (BOOL)validateLanguage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* mainActors;

//- (BOOL)validateMainActors:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* place;

//- (BOOL)validatePlace:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* recordingDate;

//- (BOOL)validateRecordingDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* section;

//- (BOOL)validateSection:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* source;

//- (BOOL)validateSource:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* subscriptionId;

//- (BOOL)validateSubscriptionId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* thumbnailUrl;

//- (BOOL)validateThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* title;

//- (BOOL)validateTitle:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* uirlHDS;

//- (BOOL)validateUirlHDS:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* url;

//- (BOOL)validateUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* urlDash;

//- (BOOL)validateUrlDash:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* urlHLS;

//- (BOOL)validateUrlHLS:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* urlProgressive;

//- (BOOL)validateUrlProgressive:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* urlSmoothStreaming;

//- (BOOL)validateUrlSmoothStreaming:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* videoLength;

//- (BOOL)validateVideoLength:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* videoTypes;

//- (BOOL)validateVideoTypes:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPSubscriptionVideoModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAreaDepartment;
- (void)setPrimitiveAreaDepartment:(NSString*)value;

- (NSString*)primitiveCamera;
- (void)setPrimitiveCamera:(NSString*)value;

- (NSString*)primitiveDescriptionSubscriptionVideo;
- (void)setPrimitiveDescriptionSubscriptionVideo:(NSString*)value;

- (NSDate*)primitiveEventDateTime;
- (void)setPrimitiveEventDateTime:(NSDate*)value;

- (NSDate*)primitiveExpurgateDate;
- (void)setPrimitiveExpurgateDate:(NSDate*)value;

- (NSString*)primitiveIdSubscriptionVideo;
- (void)setPrimitiveIdSubscriptionVideo:(NSString*)value;

- (NSString*)primitiveLanguage;
- (void)setPrimitiveLanguage:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSData*)primitiveMainActors;
- (void)setPrimitiveMainActors:(NSData*)value;

- (NSString*)primitivePlace;
- (void)setPrimitivePlace:(NSString*)value;

- (NSDate*)primitiveRecordingDate;
- (void)setPrimitiveRecordingDate:(NSDate*)value;

- (NSString*)primitiveSection;
- (void)setPrimitiveSection:(NSString*)value;

- (NSString*)primitiveSource;
- (void)setPrimitiveSource:(NSString*)value;

- (NSString*)primitiveSubscriptionId;
- (void)setPrimitiveSubscriptionId:(NSString*)value;

- (NSString*)primitiveThumbnailUrl;
- (void)setPrimitiveThumbnailUrl:(NSString*)value;

- (NSString*)primitiveTitle;
- (void)setPrimitiveTitle:(NSString*)value;

- (NSString*)primitiveUirlHDS;
- (void)setPrimitiveUirlHDS:(NSString*)value;

- (NSString*)primitiveUrl;
- (void)setPrimitiveUrl:(NSString*)value;

- (NSString*)primitiveUrlDash;
- (void)setPrimitiveUrlDash:(NSString*)value;

- (NSString*)primitiveUrlHLS;
- (void)setPrimitiveUrlHLS:(NSString*)value;

- (NSString*)primitiveUrlProgressive;
- (void)setPrimitiveUrlProgressive:(NSString*)value;

- (NSString*)primitiveUrlSmoothStreaming;
- (void)setPrimitiveUrlSmoothStreaming:(NSString*)value;

- (NSString*)primitiveVideoLength;
- (void)setPrimitiveVideoLength:(NSString*)value;

- (NSData*)primitiveVideoTypes;
- (void)setPrimitiveVideoTypes:(NSData*)value;

@end
