//
//  _MDPVideoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPVideoModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPVideoModelAttributes {
	__unsafe_unretained NSString *areaDepartment;
	__unsafe_unretained NSString *camera;
	__unsafe_unretained NSString *competitionType;
	__unsafe_unretained NSString *descriptionVideo;
	__unsafe_unretained NSString *eventDateTime;
	__unsafe_unretained NSString *expurgateDate;
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idMatch;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *idVideo;
	__unsafe_unretained NSString *language;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *mainActors;
	__unsafe_unretained NSString *matchEventTypes;
	__unsafe_unretained NSString *matchMinute;
	__unsafe_unretained NSString *place;
	__unsafe_unretained NSString *playCount;
	__unsafe_unretained NSString *recordingDate;
	__unsafe_unretained NSString *searchCount;
	__unsafe_unretained NSString *season;
	__unsafe_unretained NSString *section;
	__unsafe_unretained NSString *source;
	__unsafe_unretained NSString *stars;
	__unsafe_unretained NSString *starsSampleCount;
	__unsafe_unretained NSString *thumbnailUrl;
	__unsafe_unretained NSString *title;
	__unsafe_unretained NSString *url;
	__unsafe_unretained NSString *urlDash;
	__unsafe_unretained NSString *urlHDS;
	__unsafe_unretained NSString *urlHLS;
	__unsafe_unretained NSString *urlProgressive;
	__unsafe_unretained NSString *urlSmoothStreaming;
	__unsafe_unretained NSString *videoLength;
	__unsafe_unretained NSString *videoTypes;
} MDPVideoModelAttributes;

@interface _MDPVideoModel : NSManagedObject

@property (nonatomic, strong) NSString* areaDepartment;

//- (BOOL)validateAreaDepartment:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* camera;

//- (BOOL)validateCamera:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* competitionType;

//- (BOOL)validateCompetitionType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* descriptionVideo;

//- (BOOL)validateDescriptionVideo:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* eventDateTime;

//- (BOOL)validateEventDateTime:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* expurgateDate;

//- (BOOL)validateExpurgateDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idMatch;

//- (BOOL)validateIdMatch:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idVideo;

//- (BOOL)validateIdVideo:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* language;

//- (BOOL)validateLanguage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* mainActors;

//- (BOOL)validateMainActors:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* matchEventTypes;

//- (BOOL)validateMatchEventTypes:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* matchMinute;

//- (BOOL)validateMatchMinute:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* place;

//- (BOOL)validatePlace:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* playCount;

@property (atomic) int64_t playCountValue;
- (int64_t)playCountValue;
- (void)setPlayCountValue:(int64_t)value_;

//- (BOOL)validatePlayCount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* recordingDate;

//- (BOOL)validateRecordingDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* searchCount;

@property (atomic) int64_t searchCountValue;
- (int64_t)searchCountValue;
- (void)setSearchCountValue:(int64_t)value_;

//- (BOOL)validateSearchCount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* season;

//- (BOOL)validateSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* section;

//- (BOOL)validateSection:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* source;

//- (BOOL)validateSource:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* stars;

//- (BOOL)validateStars:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* starsSampleCount;

@property (atomic) int64_t starsSampleCountValue;
- (int64_t)starsSampleCountValue;
- (void)setStarsSampleCountValue:(int64_t)value_;

//- (BOOL)validateStarsSampleCount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* thumbnailUrl;

//- (BOOL)validateThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* title;

//- (BOOL)validateTitle:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* url;

//- (BOOL)validateUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* urlDash;

//- (BOOL)validateUrlDash:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* urlHDS;

//- (BOOL)validateUrlHDS:(id*)value_ error:(NSError**)error_;

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

@interface _MDPVideoModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAreaDepartment;
- (void)setPrimitiveAreaDepartment:(NSString*)value;

- (NSString*)primitiveCamera;
- (void)setPrimitiveCamera:(NSString*)value;

- (NSString*)primitiveCompetitionType;
- (void)setPrimitiveCompetitionType:(NSString*)value;

- (NSString*)primitiveDescriptionVideo;
- (void)setPrimitiveDescriptionVideo:(NSString*)value;

- (NSDate*)primitiveEventDateTime;
- (void)setPrimitiveEventDateTime:(NSDate*)value;

- (NSDate*)primitiveExpurgateDate;
- (void)setPrimitiveExpurgateDate:(NSDate*)value;

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdMatch;
- (void)setPrimitiveIdMatch:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSString*)primitiveIdVideo;
- (void)setPrimitiveIdVideo:(NSString*)value;

- (NSString*)primitiveLanguage;
- (void)setPrimitiveLanguage:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSData*)primitiveMainActors;
- (void)setPrimitiveMainActors:(NSData*)value;

- (NSData*)primitiveMatchEventTypes;
- (void)setPrimitiveMatchEventTypes:(NSData*)value;

- (NSString*)primitiveMatchMinute;
- (void)setPrimitiveMatchMinute:(NSString*)value;

- (NSString*)primitivePlace;
- (void)setPrimitivePlace:(NSString*)value;

- (NSNumber*)primitivePlayCount;
- (void)setPrimitivePlayCount:(NSNumber*)value;

- (int64_t)primitivePlayCountValue;
- (void)setPrimitivePlayCountValue:(int64_t)value_;

- (NSDate*)primitiveRecordingDate;
- (void)setPrimitiveRecordingDate:(NSDate*)value;

- (NSNumber*)primitiveSearchCount;
- (void)setPrimitiveSearchCount:(NSNumber*)value;

- (int64_t)primitiveSearchCountValue;
- (void)setPrimitiveSearchCountValue:(int64_t)value_;

- (NSString*)primitiveSeason;
- (void)setPrimitiveSeason:(NSString*)value;

- (NSString*)primitiveSection;
- (void)setPrimitiveSection:(NSString*)value;

- (NSString*)primitiveSource;
- (void)setPrimitiveSource:(NSString*)value;

- (NSDecimalNumber*)primitiveStars;
- (void)setPrimitiveStars:(NSDecimalNumber*)value;

- (NSNumber*)primitiveStarsSampleCount;
- (void)setPrimitiveStarsSampleCount:(NSNumber*)value;

- (int64_t)primitiveStarsSampleCountValue;
- (void)setPrimitiveStarsSampleCountValue:(int64_t)value_;

- (NSString*)primitiveThumbnailUrl;
- (void)setPrimitiveThumbnailUrl:(NSString*)value;

- (NSString*)primitiveTitle;
- (void)setPrimitiveTitle:(NSString*)value;

- (NSString*)primitiveUrl;
- (void)setPrimitiveUrl:(NSString*)value;

- (NSString*)primitiveUrlDash;
- (void)setPrimitiveUrlDash:(NSString*)value;

- (NSString*)primitiveUrlHDS;
- (void)setPrimitiveUrlHDS:(NSString*)value;

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
