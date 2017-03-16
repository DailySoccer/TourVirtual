//
//  _MDPCompactContentModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPCompactContentModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPCompactContentModelAttributes {
	__unsafe_unretained NSString *compactContentType;
	__unsafe_unretained NSString *creationDate;
	__unsafe_unretained NSString *descriptionCompactContent;
	__unsafe_unretained NSString *favorite;
	__unsafe_unretained NSString *hashTag;
	__unsafe_unretained NSString *highLight;
	__unsafe_unretained NSString *idContent;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *lastUpdateDate;
	__unsafe_unretained NSString *linkId;
	__unsafe_unretained NSString *orderInDay;
	__unsafe_unretained NSString *orderInHighLight;
	__unsafe_unretained NSString *publishedDate;
	__unsafe_unretained NSString *resourceId;
	__unsafe_unretained NSString *title;
	__unsafe_unretained NSString *visible;
} MDPCompactContentModelAttributes;

extern const struct MDPCompactContentModelRelationships {
	__unsafe_unretained NSString *asset;
	__unsafe_unretained NSString *links;
	__unsafe_unretained NSString *pagedCompactContentResults;
} MDPCompactContentModelRelationships;

@class MDPAssetModel;
@class MDPContentLinkModel;
@class MDPPagedCompactContentModel;

@interface _MDPCompactContentModel : NSManagedObject

@property (nonatomic, strong) NSString* compactContentType;

//- (BOOL)validateCompactContentType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* creationDate;

//- (BOOL)validateCreationDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* descriptionCompactContent;

//- (BOOL)validateDescriptionCompactContent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* favorite;

@property (atomic) int64_t favoriteValue;
- (int64_t)favoriteValue;
- (void)setFavoriteValue:(int64_t)value_;

//- (BOOL)validateFavorite:(id*)value_ error:(NSError**)error_;

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

@property (nonatomic, strong) NSDate* publishedDate;

//- (BOOL)validatePublishedDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* resourceId;

//- (BOOL)validateResourceId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* title;

//- (BOOL)validateTitle:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* visible;

@property (atomic) BOOL visibleValue;
- (BOOL)visibleValue;
- (void)setVisibleValue:(BOOL)value_;

//- (BOOL)validateVisible:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPAssetModel *asset;

//- (BOOL)validateAsset:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSOrderedSet *links;

- (NSMutableOrderedSet*)linksSet;

@property (nonatomic, strong) NSSet *pagedCompactContentResults;

- (NSMutableSet*)pagedCompactContentResultsSet;

@end

@interface _MDPCompactContentModel (LinksCoreDataGeneratedAccessors)
- (void)addLinks:(NSOrderedSet*)value_;
- (void)removeLinks:(NSOrderedSet*)value_;
- (void)addLinksObject:(MDPContentLinkModel*)value_;
- (void)removeLinksObject:(MDPContentLinkModel*)value_;
@end

@interface _MDPCompactContentModel (PagedCompactContentResultsCoreDataGeneratedAccessors)
- (void)addPagedCompactContentResults:(NSSet*)value_;
- (void)removePagedCompactContentResults:(NSSet*)value_;
- (void)addPagedCompactContentResultsObject:(MDPPagedCompactContentModel*)value_;
- (void)removePagedCompactContentResultsObject:(MDPPagedCompactContentModel*)value_;
@end

@interface _MDPCompactContentModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveCompactContentType;
- (void)setPrimitiveCompactContentType:(NSString*)value;

- (NSDate*)primitiveCreationDate;
- (void)setPrimitiveCreationDate:(NSDate*)value;

- (NSString*)primitiveDescriptionCompactContent;
- (void)setPrimitiveDescriptionCompactContent:(NSString*)value;

- (NSNumber*)primitiveFavorite;
- (void)setPrimitiveFavorite:(NSNumber*)value;

- (int64_t)primitiveFavoriteValue;
- (void)setPrimitiveFavoriteValue:(int64_t)value_;

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

- (NSNumber*)primitiveOrderInDay;
- (void)setPrimitiveOrderInDay:(NSNumber*)value;

- (int64_t)primitiveOrderInDayValue;
- (void)setPrimitiveOrderInDayValue:(int64_t)value_;

- (NSNumber*)primitiveOrderInHighLight;
- (void)setPrimitiveOrderInHighLight:(NSNumber*)value;

- (int64_t)primitiveOrderInHighLightValue;
- (void)setPrimitiveOrderInHighLightValue:(int64_t)value_;

- (NSDate*)primitivePublishedDate;
- (void)setPrimitivePublishedDate:(NSDate*)value;

- (NSString*)primitiveResourceId;
- (void)setPrimitiveResourceId:(NSString*)value;

- (NSString*)primitiveTitle;
- (void)setPrimitiveTitle:(NSString*)value;

- (NSNumber*)primitiveVisible;
- (void)setPrimitiveVisible:(NSNumber*)value;

- (BOOL)primitiveVisibleValue;
- (void)setPrimitiveVisibleValue:(BOOL)value_;

- (MDPAssetModel*)primitiveAsset;
- (void)setPrimitiveAsset:(MDPAssetModel*)value;

- (NSMutableOrderedSet*)primitiveLinks;
- (void)setPrimitiveLinks:(NSMutableOrderedSet*)value;

- (NSMutableSet*)primitivePagedCompactContentResults;
- (void)setPrimitivePagedCompactContentResults:(NSMutableSet*)value;

@end
