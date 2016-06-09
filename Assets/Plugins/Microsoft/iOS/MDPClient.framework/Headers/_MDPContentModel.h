//
//  _MDPContentModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPContentModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPContentModelAttributes {
	__unsafe_unretained NSString *allowReplaceFromSource;
	__unsafe_unretained NSString *commentsIdThread;
	__unsafe_unretained NSString *contentType;
	__unsafe_unretained NSString *creationDate;
	__unsafe_unretained NSString *descriptionContent;
	__unsafe_unretained NSString *hasGamification;
	__unsafe_unretained NSString *hashTag;
	__unsafe_unretained NSString *highLight;
	__unsafe_unretained NSString *idContent;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *lastUpdateDate;
	__unsafe_unretained NSString *linkId;
	__unsafe_unretained NSString *localeId;
	__unsafe_unretained NSString *notificationsTags;
	__unsafe_unretained NSString *orderInDay;
	__unsafe_unretained NSString *orderInHighLight;
	__unsafe_unretained NSString *published;
	__unsafe_unretained NSString *publishedDate;
	__unsafe_unretained NSString *sourceId;
	__unsafe_unretained NSString *title;
	__unsafe_unretained NSString *visible;
} MDPContentModelAttributes;

extern const struct MDPContentModelRelationships {
	__unsafe_unretained NSString *assets;
	__unsafe_unretained NSString *body;
	__unsafe_unretained NSString *links;
	__unsafe_unretained NSString *relatedNews;
	__unsafe_unretained NSString *relatedPlayers;
} MDPContentModelRelationships;

@class MDPAssetModel;
@class MDPContentParagraphModel;
@class MDPContentLinkModel;
@class MDPContentLinkModel;
@class MDPContentPlayerModel;

@interface _MDPContentModel : NSManagedObject

@property (nonatomic, strong) NSNumber* allowReplaceFromSource;

@property (atomic) BOOL allowReplaceFromSourceValue;
- (BOOL)allowReplaceFromSourceValue;
- (void)setAllowReplaceFromSourceValue:(BOOL)value_;

//- (BOOL)validateAllowReplaceFromSource:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* commentsIdThread;

//- (BOOL)validateCommentsIdThread:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* contentType;

@property (atomic) uint16_t contentTypeValue;
- (uint16_t)contentTypeValue;
- (void)setContentTypeValue:(uint16_t)value_;

//- (BOOL)validateContentType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* creationDate;

//- (BOOL)validateCreationDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* descriptionContent;

//- (BOOL)validateDescriptionContent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* hasGamification;

@property (atomic) BOOL hasGamificationValue;
- (BOOL)hasGamificationValue;
- (void)setHasGamificationValue:(BOOL)value_;

//- (BOOL)validateHasGamification:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* hashTag;

//- (BOOL)validateHashTag:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* highLight;

@property (atomic) BOOL highLightValue;
- (BOOL)highLightValue;
- (void)setHighLightValue:(BOOL)value_;

//- (BOOL)validateHighLight:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idContent;

//- (BOOL)validateIdContent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateDate;

//- (BOOL)validateLastUpdateDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* linkId;

//- (BOOL)validateLinkId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* localeId;

//- (BOOL)validateLocaleId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* notificationsTags;

//- (BOOL)validateNotificationsTags:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* orderInDay;

@property (atomic) int64_t orderInDayValue;
- (int64_t)orderInDayValue;
- (void)setOrderInDayValue:(int64_t)value_;

//- (BOOL)validateOrderInDay:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* orderInHighLight;

@property (atomic) int64_t orderInHighLightValue;
- (int64_t)orderInHighLightValue;
- (void)setOrderInHighLightValue:(int64_t)value_;

//- (BOOL)validateOrderInHighLight:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* published;

@property (atomic) BOOL publishedValue;
- (BOOL)publishedValue;
- (void)setPublishedValue:(BOOL)value_;

//- (BOOL)validatePublished:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* publishedDate;

//- (BOOL)validatePublishedDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* sourceId;

//- (BOOL)validateSourceId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* title;

//- (BOOL)validateTitle:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* visible;

@property (atomic) BOOL visibleValue;
- (BOOL)visibleValue;
- (void)setVisibleValue:(BOOL)value_;

//- (BOOL)validateVisible:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSOrderedSet *assets;

- (NSMutableOrderedSet*)assetsSet;

@property (nonatomic, strong) NSOrderedSet *body;

- (NSMutableOrderedSet*)bodySet;

@property (nonatomic, strong) NSSet *links;

- (NSMutableSet*)linksSet;

@property (nonatomic, strong) NSOrderedSet *relatedNews;

- (NSMutableOrderedSet*)relatedNewsSet;

@property (nonatomic, strong) NSSet *relatedPlayers;

- (NSMutableSet*)relatedPlayersSet;

@end

@interface _MDPContentModel (AssetsCoreDataGeneratedAccessors)
- (void)addAssets:(NSOrderedSet*)value_;
- (void)removeAssets:(NSOrderedSet*)value_;
- (void)addAssetsObject:(MDPAssetModel*)value_;
- (void)removeAssetsObject:(MDPAssetModel*)value_;
@end

@interface _MDPContentModel (BodyCoreDataGeneratedAccessors)
- (void)addBody:(NSOrderedSet*)value_;
- (void)removeBody:(NSOrderedSet*)value_;
- (void)addBodyObject:(MDPContentParagraphModel*)value_;
- (void)removeBodyObject:(MDPContentParagraphModel*)value_;
@end

@interface _MDPContentModel (LinksCoreDataGeneratedAccessors)
- (void)addLinks:(NSSet*)value_;
- (void)removeLinks:(NSSet*)value_;
- (void)addLinksObject:(MDPContentLinkModel*)value_;
- (void)removeLinksObject:(MDPContentLinkModel*)value_;
@end

@interface _MDPContentModel (RelatedNewsCoreDataGeneratedAccessors)
- (void)addRelatedNews:(NSOrderedSet*)value_;
- (void)removeRelatedNews:(NSOrderedSet*)value_;
- (void)addRelatedNewsObject:(MDPContentLinkModel*)value_;
- (void)removeRelatedNewsObject:(MDPContentLinkModel*)value_;
@end

@interface _MDPContentModel (RelatedPlayersCoreDataGeneratedAccessors)
- (void)addRelatedPlayers:(NSSet*)value_;
- (void)removeRelatedPlayers:(NSSet*)value_;
- (void)addRelatedPlayersObject:(MDPContentPlayerModel*)value_;
- (void)removeRelatedPlayersObject:(MDPContentPlayerModel*)value_;
@end

@interface _MDPContentModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveAllowReplaceFromSource;
- (void)setPrimitiveAllowReplaceFromSource:(NSNumber*)value;

- (BOOL)primitiveAllowReplaceFromSourceValue;
- (void)setPrimitiveAllowReplaceFromSourceValue:(BOOL)value_;

- (NSString*)primitiveCommentsIdThread;
- (void)setPrimitiveCommentsIdThread:(NSString*)value;

- (NSNumber*)primitiveContentType;
- (void)setPrimitiveContentType:(NSNumber*)value;

- (uint16_t)primitiveContentTypeValue;
- (void)setPrimitiveContentTypeValue:(uint16_t)value_;

- (NSDate*)primitiveCreationDate;
- (void)setPrimitiveCreationDate:(NSDate*)value;

- (NSString*)primitiveDescriptionContent;
- (void)setPrimitiveDescriptionContent:(NSString*)value;

- (NSNumber*)primitiveHasGamification;
- (void)setPrimitiveHasGamification:(NSNumber*)value;

- (BOOL)primitiveHasGamificationValue;
- (void)setPrimitiveHasGamificationValue:(BOOL)value_;

- (NSString*)primitiveHashTag;
- (void)setPrimitiveHashTag:(NSString*)value;

- (NSNumber*)primitiveHighLight;
- (void)setPrimitiveHighLight:(NSNumber*)value;

- (BOOL)primitiveHighLightValue;
- (void)setPrimitiveHighLightValue:(BOOL)value_;

- (NSString*)primitiveIdContent;
- (void)setPrimitiveIdContent:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSDate*)primitiveLastUpdateDate;
- (void)setPrimitiveLastUpdateDate:(NSDate*)value;

- (NSString*)primitiveLinkId;
- (void)setPrimitiveLinkId:(NSString*)value;

- (NSString*)primitiveLocaleId;
- (void)setPrimitiveLocaleId:(NSString*)value;

- (NSData*)primitiveNotificationsTags;
- (void)setPrimitiveNotificationsTags:(NSData*)value;

- (NSNumber*)primitiveOrderInDay;
- (void)setPrimitiveOrderInDay:(NSNumber*)value;

- (int64_t)primitiveOrderInDayValue;
- (void)setPrimitiveOrderInDayValue:(int64_t)value_;

- (NSNumber*)primitiveOrderInHighLight;
- (void)setPrimitiveOrderInHighLight:(NSNumber*)value;

- (int64_t)primitiveOrderInHighLightValue;
- (void)setPrimitiveOrderInHighLightValue:(int64_t)value_;

- (NSNumber*)primitivePublished;
- (void)setPrimitivePublished:(NSNumber*)value;

- (BOOL)primitivePublishedValue;
- (void)setPrimitivePublishedValue:(BOOL)value_;

- (NSDate*)primitivePublishedDate;
- (void)setPrimitivePublishedDate:(NSDate*)value;

- (NSString*)primitiveSourceId;
- (void)setPrimitiveSourceId:(NSString*)value;

- (NSString*)primitiveTitle;
- (void)setPrimitiveTitle:(NSString*)value;

- (NSNumber*)primitiveVisible;
- (void)setPrimitiveVisible:(NSNumber*)value;

- (BOOL)primitiveVisibleValue;
- (void)setPrimitiveVisibleValue:(BOOL)value_;

- (NSMutableOrderedSet*)primitiveAssets;
- (void)setPrimitiveAssets:(NSMutableOrderedSet*)value;

- (NSMutableOrderedSet*)primitiveBody;
- (void)setPrimitiveBody:(NSMutableOrderedSet*)value;

- (NSMutableSet*)primitiveLinks;
- (void)setPrimitiveLinks:(NSMutableSet*)value;

- (NSMutableOrderedSet*)primitiveRelatedNews;
- (void)setPrimitiveRelatedNews:(NSMutableOrderedSet*)value;

- (NSMutableSet*)primitiveRelatedPlayers;
- (void)setPrimitiveRelatedPlayers:(NSMutableSet*)value;

@end
