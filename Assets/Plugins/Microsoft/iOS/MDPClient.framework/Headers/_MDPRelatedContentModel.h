//
//  _MDPRelatedContentModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPRelatedContentModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPRelatedContentModelAttributes {
	__unsafe_unretained NSString *date;
	__unsafe_unretained NSString *descriptionRelatedContent;
	__unsafe_unretained NSString *idContent;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *locale;
	__unsafe_unretained NSString *relatedUrl;
} MDPRelatedContentModelAttributes;

extern const struct MDPRelatedContentModelRelationships {
	__unsafe_unretained NSString *mediaContentRelatedContent;
} MDPRelatedContentModelRelationships;

@class MDPMediaContentModel;

@interface _MDPRelatedContentModel : NSManagedObject

@property (nonatomic, strong) NSDate* date;

//- (BOOL)validateDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* descriptionRelatedContent;

//- (BOOL)validateDescriptionRelatedContent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idContent;

//- (BOOL)validateIdContent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* locale;

//- (BOOL)validateLocale:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* relatedUrl;

//- (BOOL)validateRelatedUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *mediaContentRelatedContent;

- (NSMutableSet*)mediaContentRelatedContentSet;

@end

@interface _MDPRelatedContentModel (MediaContentRelatedContentCoreDataGeneratedAccessors)
- (void)addMediaContentRelatedContent:(NSSet*)value_;
- (void)removeMediaContentRelatedContent:(NSSet*)value_;
- (void)addMediaContentRelatedContentObject:(MDPMediaContentModel*)value_;
- (void)removeMediaContentRelatedContentObject:(MDPMediaContentModel*)value_;
@end

@interface _MDPRelatedContentModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveDate;
- (void)setPrimitiveDate:(NSDate*)value;

- (NSString*)primitiveDescriptionRelatedContent;
- (void)setPrimitiveDescriptionRelatedContent:(NSString*)value;

- (NSString*)primitiveIdContent;
- (void)setPrimitiveIdContent:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveLocale;
- (void)setPrimitiveLocale:(NSString*)value;

- (NSString*)primitiveRelatedUrl;
- (void)setPrimitiveRelatedUrl:(NSString*)value;

- (NSMutableSet*)primitiveMediaContentRelatedContent;
- (void)setPrimitiveMediaContentRelatedContent:(NSMutableSet*)value;

@end
