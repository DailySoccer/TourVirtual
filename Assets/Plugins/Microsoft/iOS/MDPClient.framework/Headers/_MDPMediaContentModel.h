//
//  _MDPMediaContentModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPMediaContentModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPMediaContentModelAttributes {
	__unsafe_unretained NSString *contentType;
	__unsafe_unretained NSString *idMediaContent;
	__unsafe_unretained NSString *imageLinkUrl;
	__unsafe_unretained NSString *imageUrl;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *thumbnailUrl;
} MDPMediaContentModelAttributes;

extern const struct MDPMediaContentModelRelationships {
	__unsafe_unretained NSString *matchContent;
	__unsafe_unretained NSString *playerBasicInfoContent;
	__unsafe_unretained NSString *playerContent;
	__unsafe_unretained NSString *relatedContent;
	__unsafe_unretained NSString *teamContent;
} MDPMediaContentModelRelationships;

@class MDPMatchModel;
@class MDPPlayerBasicInfoModel;
@class MDPPlayerModel;
@class MDPRelatedContentModel;
@class MDPTeamModel;

@interface _MDPMediaContentModel : NSManagedObject

@property (nonatomic, strong) NSNumber* contentType;

@property (atomic) uint16_t contentTypeValue;
- (uint16_t)contentTypeValue;
- (void)setContentTypeValue:(uint16_t)value_;

//- (BOOL)validateContentType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idMediaContent;

//- (BOOL)validateIdMediaContent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* imageLinkUrl;

//- (BOOL)validateImageLinkUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* imageUrl;

//- (BOOL)validateImageUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* thumbnailUrl;

//- (BOOL)validateThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *matchContent;

- (NSMutableSet*)matchContentSet;

@property (nonatomic, strong) NSSet *playerBasicInfoContent;

- (NSMutableSet*)playerBasicInfoContentSet;

@property (nonatomic, strong) NSSet *playerContent;

- (NSMutableSet*)playerContentSet;

@property (nonatomic, strong) NSSet *relatedContent;

- (NSMutableSet*)relatedContentSet;

@property (nonatomic, strong) NSSet *teamContent;

- (NSMutableSet*)teamContentSet;

@end

@interface _MDPMediaContentModel (MatchContentCoreDataGeneratedAccessors)
- (void)addMatchContent:(NSSet*)value_;
- (void)removeMatchContent:(NSSet*)value_;
- (void)addMatchContentObject:(MDPMatchModel*)value_;
- (void)removeMatchContentObject:(MDPMatchModel*)value_;
@end

@interface _MDPMediaContentModel (PlayerBasicInfoContentCoreDataGeneratedAccessors)
- (void)addPlayerBasicInfoContent:(NSSet*)value_;
- (void)removePlayerBasicInfoContent:(NSSet*)value_;
- (void)addPlayerBasicInfoContentObject:(MDPPlayerBasicInfoModel*)value_;
- (void)removePlayerBasicInfoContentObject:(MDPPlayerBasicInfoModel*)value_;
@end

@interface _MDPMediaContentModel (PlayerContentCoreDataGeneratedAccessors)
- (void)addPlayerContent:(NSSet*)value_;
- (void)removePlayerContent:(NSSet*)value_;
- (void)addPlayerContentObject:(MDPPlayerModel*)value_;
- (void)removePlayerContentObject:(MDPPlayerModel*)value_;
@end

@interface _MDPMediaContentModel (RelatedContentCoreDataGeneratedAccessors)
- (void)addRelatedContent:(NSSet*)value_;
- (void)removeRelatedContent:(NSSet*)value_;
- (void)addRelatedContentObject:(MDPRelatedContentModel*)value_;
- (void)removeRelatedContentObject:(MDPRelatedContentModel*)value_;
@end

@interface _MDPMediaContentModel (TeamContentCoreDataGeneratedAccessors)
- (void)addTeamContent:(NSSet*)value_;
- (void)removeTeamContent:(NSSet*)value_;
- (void)addTeamContentObject:(MDPTeamModel*)value_;
- (void)removeTeamContentObject:(MDPTeamModel*)value_;
@end

@interface _MDPMediaContentModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveContentType;
- (void)setPrimitiveContentType:(NSNumber*)value;

- (uint16_t)primitiveContentTypeValue;
- (void)setPrimitiveContentTypeValue:(uint16_t)value_;

- (NSString*)primitiveIdMediaContent;
- (void)setPrimitiveIdMediaContent:(NSString*)value;

- (NSString*)primitiveImageLinkUrl;
- (void)setPrimitiveImageLinkUrl:(NSString*)value;

- (NSString*)primitiveImageUrl;
- (void)setPrimitiveImageUrl:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveThumbnailUrl;
- (void)setPrimitiveThumbnailUrl:(NSString*)value;

- (NSMutableSet*)primitiveMatchContent;
- (void)setPrimitiveMatchContent:(NSMutableSet*)value;

- (NSMutableSet*)primitivePlayerBasicInfoContent;
- (void)setPrimitivePlayerBasicInfoContent:(NSMutableSet*)value;

- (NSMutableSet*)primitivePlayerContent;
- (void)setPrimitivePlayerContent:(NSMutableSet*)value;

- (NSMutableSet*)primitiveRelatedContent;
- (void)setPrimitiveRelatedContent:(NSMutableSet*)value;

- (NSMutableSet*)primitiveTeamContent;
- (void)setPrimitiveTeamContent:(NSMutableSet*)value;

@end
